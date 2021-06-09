using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace StockTracker
{
    class Program
    {

        // API Key: c2t8pnaad3i9opckm81g
        // url: https://finnhub.io/api/v1/quote?symbol=GME&token=c2t8pnaad3i9opckm81g

        // import requests
        //r = requests.get('https://finnhub.io/api/v1/quote?symbol=AAPL&token=c2t8pnaad3i9opckm81g')
        // AAPL = stock symbol in above url
        //print(r.json())

        
        static HttpClient _client = new HttpClient();
        static Mutex _lock = new Mutex();
        static Dictionary<string, List<decimal>> _prices = new Dictionary<string, List<decimal>>();

        static void Main(string[] args)
        {
            // create list of tasks and stocks
            List<Task> tasks = new List<Task>();
            List<string> stocks = new List<string>();
            

            // prompt user to enter stock
            AddNewStock(stocks);

            foreach (string stock in stocks)
            {
                tasks.Add(Task.Factory.StartNew(() => CheckCurrentPrice(stock)).Unwrap());
            }

            Task.WaitAll(tasks.ToArray());

            foreach (string stock in stocks)
            {
                Console.WriteLine(stock);
            }
        }


        // method to add stocks to watch
        static List<string> AddNewStock(List<string> stocks)
        {
            
            bool doneAdding = false;

            while (!doneAdding)
            {
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
            stockPrices.Sort();
            if (stockPrices.Count % 2 == 0)
            {
                decimal mid1 = stockPrices[(stockPrices.Count / 2) - 1];
                decimal mid2 = stockPrices[stockPrices.Count / 2];
                return (mid1 + mid2) / 2;
            }
            else
            {
                return stockPrices[stockPrices.Count / 2];
            }
        }

        static async Task CheckCurrentPrice(string symbol)
        {
            while (true)
            {
                try
                {
                    HttpResponseMessage res = await _client.GetAsync($"https://finnhub.io/api/v1/quote?symbol={symbol}&token=c2t8pnaad3i9opckm81g");
                    res.EnsureSuccessStatusCode();
                    string body = await res.Content.ReadAsStringAsync();
                    Match m = Regex.Match(body, @"(?<={""c"":)[^,]+");
                    decimal price = decimal.Parse(m.ToString());
                    _lock.WaitOne();
                    if(_prices.ContainsKey(symbol))
                    {
                        if(_prices.GetValueOrDefault(symbol).Count > 2)
                        {
                            decimal med = GetMedianPrice(_prices.GetValueOrDefault(symbol));
                            if ( price < med )
                            {
                                Console.WriteLine($"{symbol} is below its median price by -{price - med}. You should buy.");
                            }
                            else if (price > med)
                            {
                                Console.WriteLine($"{symbol} is above its median price by +{price - med}. You should sell.");
                            }
                        }
                        _prices.GetValueOrDefault(symbol).Add(price);
                    }
                    else
                    {
                        _prices.Add(symbol, new List<decimal> { price });
                    }
                    _lock.ReleaseMutex();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                await Task.Delay(60000);
            }
        }
    }
}
