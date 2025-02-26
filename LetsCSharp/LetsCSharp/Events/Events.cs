using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsCSharp.Events
{

    /// <summary>
    /// Define Custom EventArgs:
    /// We start by defining a custom EventArgs class StockPriceChangedEventArgs to encapsulate information about the stock price change.
    /// </summary>
    // Custom EventArgs class for passing stock price change information
    public class StockPriceChangedEventArgs : EventArgs
    {
        public string StockSymbol { get; }
        public decimal NewPrice { get; }

        public StockPriceChangedEventArgs(string stockSymbol, decimal newPrice)
        {
            StockSymbol = stockSymbol;
            NewPrice = newPrice;
        }
    }

    /// <summary>
    /// Publisher Class — Stock: The Stock class represents a stock with properties for Symbol and Price. 
    /// It defines a delegate StockPriceChangedHandler and an event StockPriceChanged for notifying price changes.
    /// </summary>
    public class Stock
    {
        // Delegate for stock price change event handler
        public delegate void StockPriceChangedHandler(object sender, StockPriceChangedEventArgs e);

        // Event for notifying stock price changes
        public event StockPriceChangedHandler StockPriceChanged ;

        private decimal price;
        public string Symbol { get; }

        public Stock(string symbol, decimal initialPrice)
        {
            Symbol = symbol;
            price = initialPrice;
        }

        // Property for updating the stock price and raising the event
        public decimal Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    OnStockPriceChanged(new StockPriceChangedEventArgs(Symbol, value));
                }
            }
        }

        // Method for raising the stock price change event
        protected virtual void OnStockPriceChanged(StockPriceChangedEventArgs e)
        {
            StockPriceChanged?.Invoke(this, e);
        }
    }

    /// <summary>
    /// Subscriber — Investors: 
    /// In our example, two investors (Investor1 and Investor2) are subscribers to the StockPriceChanged event. 
    /// They each have event handler methods (Investor1_StockPriceChanged and Investor2_StockPriceChanged) that are invoked when the stock price changes.
    /// </summary>
    public static class Investors
    {
        public static void Raise()
        {
            // Create a new stock instance
            Stock appleStock = new Stock("AAPL", 150.00m);

            // Subscribe multiple investors to the stock price change event
            appleStock.StockPriceChanged += Investor1_StockPriceChanged;
            appleStock.StockPriceChanged += Investor2_StockPriceChanged;

            // Simulate stock price changes
            appleStock.Price = 155.00m;
            appleStock.Price = 160.00m;
        }

        // Event handler method for Investor 1
        private static void Investor1_StockPriceChanged(object sender, StockPriceChangedEventArgs e)
        {
            Console.WriteLine($"Investor 1: The price of {e.StockSymbol} changed to {e.NewPrice:C}");
        }

        // Event handler method for Investor 2
        private static void Investor2_StockPriceChanged(object sender, StockPriceChangedEventArgs e)
        {
            Console.WriteLine($"Investor 2: The price of {e.StockSymbol} changed to {e.NewPrice:C}");
        }
    }
}
