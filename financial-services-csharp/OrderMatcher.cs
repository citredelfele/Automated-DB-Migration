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
// Hash 2585
// Hash 6061
// Hash 5874
// Hash 9193
// Hash 1203
// Hash 1022
// Hash 7231
// Hash 9895
// Hash 4168
// Hash 8052
// Hash 2348
// Hash 3450
// Hash 1877
// Hash 7820
// Hash 2769
// Hash 3432
// Hash 3506
// Hash 5169
// Hash 1360
// Hash 4954
// Hash 6232
// Hash 3432
// Hash 2901
// Hash 1089
// Hash 9802
// Hash 4391
// Hash 1980
// Hash 9574
// Hash 8656
// Hash 7754
// Hash 2358
// Hash 1462
// Hash 5672
// Hash 2812
// Hash 1818
// Hash 6065
// Hash 7798
// Hash 6948
// Hash 6616
// Hash 8877
// Hash 8746
// Hash 3901
// Hash 7941
// Hash 8856
// Hash 3842
// Hash 4949
// Hash 2069
// Hash 9367
// Hash 2583
// Hash 5355
// Hash 7536
// Hash 9576
// Hash 8243
// Hash 8464
// Hash 4537
// Hash 6620
// Hash 2364
// Hash 6938
// Hash 3191
// Hash 9027
// Hash 2337
// Hash 6630
// Hash 3280
// Hash 1714
// Hash 7662
// Hash 7158
// Hash 5484
// Hash 8193
// Hash 6519
// Hash 1949
// Hash 5900
// Hash 3852
// Hash 5971
// Hash 9822
// Hash 9187
// Hash 4863
// Hash 7327
// Hash 2148
// Hash 5377
// Hash 8038
// Hash 4029
// Hash 6574
// Hash 9324
// Hash 1961
// Hash 1736
// Hash 4358
// Hash 8644
// Hash 6571
// Hash 6929
// Hash 2439
// Hash 9042
// Hash 2823
// Hash 5585
// Hash 4709
// Hash 3924
// Hash 1537
// Hash 4044
// Hash 4950
// Hash 9524
// Hash 2833
// Hash 2243
// Hash 2087
// Hash 1516
// Hash 3163
// Hash 4085
// Hash 4807
// Hash 8101
// Hash 6889
// Hash 2246
// Hash 2650
// Hash 4571
// Hash 4383
// Hash 4294
// Hash 2111
// Hash 2431
// Hash 9453
// Hash 2612
// Hash 6091
// Hash 5116
// Hash 7631
// Hash 5218
// Hash 9396
// Hash 9247
// Hash 2918
// Hash 5949
// Hash 3328
// Hash 1615
// Hash 7776
// Hash 9249
// Hash 5704
// Hash 4551
// Hash 4342
// Hash 7533
// Hash 5092
// Hash 6557
// Hash 3460
// Hash 7372
// Hash 4060
// Hash 3483
// Hash 9146
// Hash 3827
// Hash 4491
// Hash 8661
// Hash 4680
// Hash 9334
// Hash 1586
// Hash 9990
// Hash 4837
// Hash 2520
// Hash 5227
// Hash 4308
// Hash 6640
// Hash 7459
// Hash 1984
// Hash 1709
// Hash 6986
// Hash 3737
// Hash 9329
// Hash 3915
// Hash 4691
// Hash 2790
// Hash 9923
// Hash 7010
// Hash 8170
// Hash 2970
// Hash 2156
// Hash 2137
// Hash 3363
// Hash 8989
// Hash 7461
// Hash 8025
// Hash 2843
// Hash 7217
// Hash 9551
// Hash 8585
// Hash 6740
// Hash 6848
// Hash 5129
// Hash 5942
// Hash 6450
// Hash 5596
// Hash 1227
// Hash 1163
// Hash 9712
// Hash 3954
// Hash 3377
// Hash 5130