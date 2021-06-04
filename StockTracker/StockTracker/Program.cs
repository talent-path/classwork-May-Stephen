using System;
using System.Collections.Generic;
using System.Net.Http;
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

        static string _url = "https://finnhub.io/api/v1/quote?symbol=GME&token=c2t8pnaad3i9opckm81g";

        static HttpClient _client = new HttpClient();

        static async Task Main(string[] args)
        {
            // create list of tasks and stocks
            List<Task> tasks = new List<Task>();
            List<string> stocks = new List<string>();

            // prompt user to enter stock
            AddNewStock(stocks);

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
                string stock = Console.ReadLine();
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
    }
}
