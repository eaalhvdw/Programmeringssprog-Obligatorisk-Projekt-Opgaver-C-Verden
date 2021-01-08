using System;

namespace LHH_Opgave4
{
    class Program
    {
        // Subscriber method for an increased pricechange.
        static void StockPriceIncreased(object sender, decimal oldPrice, decimal price)
        {
            Console.WriteLine("Stock price increased!");
        }

        // Subscriber method for a decreased pricechange.
        static void StockPriceDecreased(object sender, decimal oldPrice, decimal price)
        {
            Console.WriteLine("Stock price decreased!");
        }

        static void Main(string[] args)
        {
            Stock stock = new Stock("THPW");
            stock.Price = 27.10M;
            Console.WriteLine("Current stock price: " + stock.Price);
            // Register with the PriceIncreased event.
            stock.PriceIncreased += StockPriceIncreased;
            Console.WriteLine("StockPriceIncreased registered with the PriceIncreased event.");
            // Register with the PriceDecreased event.
            stock.PriceDecreased += StockPriceDecreased;
            Console.WriteLine("StockPriceDecreased registered with the PriceDecreased event.");
            stock.Price = 31.59M;   // Expected: PriceIncreased executes.
            Console.WriteLine("Current stock price: " + stock.Price);
            stock.Price = 29.25M;   // Expected: PriceDecreased executes.
            Console.WriteLine("Current stock price: " + stock.Price);
            stock.Price = 30.00M;   // Expected: PriceIncreased executes.
            Console.WriteLine("Current stock price: " + stock.Price);
            // Unregister with the PriceIncreased event.
            stock.PriceIncreased -= StockPriceIncreased;
            Console.WriteLine("StockPriceIncreased unregistered with the PriceIncreased event.");
            stock.Price = 31.59M;   // Expected: No output.
            Console.WriteLine("Current stock price: " + stock.Price);
            stock.Price = 10.50M;   // Expected: PriceDecreased executes.
            Console.WriteLine("Current stock price: " + stock.Price);
            // Unregister with the PriceDecreased event.
            stock.PriceDecreased -= StockPriceDecreased;
            Console.WriteLine("StockPriceDecreased unregistered with the PriceDecreased event.");
            stock.Price = 9.79M;    // Expected: No output.
            Console.WriteLine("Current stock price: " + stock.Price);
            Console.ReadLine();
        }
    }
}
