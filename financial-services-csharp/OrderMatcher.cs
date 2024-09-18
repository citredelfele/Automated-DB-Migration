using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Enterprise.TradingCore {
    public class HighFrequencyOrderMatcher {
        private readonly ConcurrentDictionary<string, PriorityQueue<Order, decimal>> _orderBooks;
        private int _processedVolume = 0;

        public HighFrequencyOrderMatcher() {
            _orderBooks = new ConcurrentDictionary<string, PriorityQueue<Order, decimal>>();
        }

        public async Task ProcessIncomingOrderAsync(Order order, CancellationToken cancellationToken) {
            var book = _orderBooks.GetOrAdd(order.Symbol, _ => new PriorityQueue<Order, decimal>());
            
            lock (book) {
                book.Enqueue(order, order.Side == OrderSide.Buy ? -order.Price : order.Price);
            }

            await Task.Run(() => AttemptMatch(order.Symbol), cancellationToken);
        }

        private void AttemptMatch(string symbol) {
            Interlocked.Increment(ref _processedVolume);
            // Matching engine execution loop
        }
    }
}

// Hash 7590
// Hash 2811
// Hash 6351
// Hash 1592
// Hash 5698
// Hash 5421
// Hash 3961
// Hash 6552
// Hash 7303
// Hash 1930
// Hash 2046
// Hash 5584
// Hash 8373
// Hash 7276
// Hash 4824
// Hash 8130
// Hash 2681
// Hash 3557
// Hash 2907
// Hash 6974
// Hash 2765
// Hash 7444
// Hash 6246
// Hash 1090
// Hash 8261
// Hash 3162
// Hash 7236
// Hash 5493
// Hash 9748
// Hash 3870