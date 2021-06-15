using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutoTrader
{
    class Program
    {


        static HttpClient _client = new HttpClient();
        static Mutex _mutex = new Mutex();
        static Dictionary<string, List<decimal>> _pricesPerStock = new Dictionary<string, List<decimal>>();


        static void Main(string[] args)
        {
            // create list of tasks and stocks
            List<Task> tasks = new List<Task>();
            List<string> stocks = new List<string>();


            // prompt user to enter stock
            AddNewStock(stocks);
            Console.WriteLine("Processing data.....");

            foreach (string stock in stocks)
            {
                tasks.Add(Task.Factory.StartNew(() => GetCurrentPrice(stock)).Unwrap());
            }

            Task.WaitAll(tasks.ToArray());


        }

        static async Task GetCurrentPrice(string stock)
        {
            // loop infinitely to get price updates every min
            while (true)
            {
                try
                {
                    // get stock's data
                    HttpResponseMessage res = await _client.GetAsync($"https://finnhub.io/api/v1/quote?symbol={stock}&token=c2t8pnaad3i9opckm81g");
                    res.EnsureSuccessStatusCode();

                    // convert to string
                    string data = await res.Content.ReadAsStringAsync();

                    // check for 'c' for closing price
                    Match match = Regex.Match(data, @"(?<={""c"":)[^,]+");

                    // convert price to decimal
                    decimal price = decimal.Parse(match.ToString());
                    _mutex.WaitOne();

                    //compare current price to median
                    CompareToMedian(stock, price);

                    _mutex.ReleaseMutex();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                // delay for 1 minute
                await Task.Delay(6000);
            }
        }

        static void CompareToMedian(string stock, decimal price)
        {
            // check if stock is already in dictionary
            if (_pricesPerStock.ContainsKey(stock))
            {
                // check for at least two values to get median
                if (_pricesPerStock.GetValueOrDefault(stock).Count > 2)
                {
                    decimal median = GetMedianPrice(_pricesPerStock.GetValueOrDefault(stock));
                    // check if current price is above or below median
                    // alert user to sell or buy
                    if (price < median)
                    {
                        Console.WriteLine($"{stock} is below its median price by {price - median}. You should buy.");
                    }
                    else if (price > median)
                    {
                        Console.WriteLine($"{stock} is above its median price by +{price - median}. You should sell.");
                    }
                    else if (price == median)
                    {
                        Console.WriteLine($"{stock} is currently at its median price of {price}. You should hold.");
                    }
                }

                // add current price to dictionary
                _pricesPerStock.GetValueOrDefault(stock).Add(price);

            }
            else
            {
                // add stock to dictionary if not there already
                _pricesPerStock.Add(stock, new List<decimal> { price });
            }
        }

        static List<string> AddNewStock(List<string> stocks)
        {
            bool doneAdding = false;
            while (!doneAdding)
            {
                // prompt user to enter a stock to track
                // store in list
                Console.WriteLine("Enter a stock to track. Enter a blank line to stop adding.");
                string stock = Console.ReadLine().ToUpper();
                if (stock == "")
                {
                    doneAdding = true;
                }
                else
                {
                    stocks.Add(stock);
                }


            }
            return stocks;
        }

        static decimal GetMedianPrice(List<decimal> stockPrices)
        {
            //place prices in order to get correct median
            stockPrices.Sort();

            // if count is even, need to take average of two middle numbers
            if (stockPrices.Count % 2 == 0)
            {
                decimal mid1 = stockPrices[(stockPrices.Count / 2) - 1];
                decimal mid2 = stockPrices[(stockPrices.Count / 2)];
                return (mid1 + mid2) / 2;
            }
            // else if odd, return median
            else
            {
                return stockPrices[(stockPrices.Count / 2)];
            }
        }

    }
}
