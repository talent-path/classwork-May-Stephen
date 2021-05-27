using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NasdaqReader
{
    class Program
    {
        

        static void Main(string[] args)
        {
            // Group data by year
            // Get standard deviation for open, low, high, and close (volume extra)
            // dictionary to map year to output of ^ (list)
            // could also make a class to hold the report
            List<DailyQuote> quotes = new List<DailyQuote>();


            using (StreamReader reader = new StreamReader("HistoricalData_1622126579844.csv"))
            {
                
                
                string line = null;
                string header = reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {
                    DailyQuote quote = new DailyQuote(line);
                    quotes.Add(quote);
 
                }
                
            }
            Dictionary<int, List<DailyQuote>> groupedByYear = GroupByYear(quotes);

            
            List<ulong> volList = new List<ulong>();
            

            foreach (KeyValuePair<int, List<DailyQuote>> values in groupedByYear)
            {
                List<decimal> closeList = new List<decimal>();
                List<decimal> openList = new List<decimal>();
                List<decimal> highList = new List<decimal>();
                List<decimal> lowList = new List<decimal>();
                foreach (DailyQuote data in values.Value)
                {
                    closeList.Add(data.Close);
                    openList.Add(data.Open);
                    highList.Add(data.High);
                    lowList.Add(data.Low);
                }

                decimal stdLow = StandardDeviation(lowList);
                decimal stdHigh = StandardDeviation(highList);
                decimal stdOpen = StandardDeviation(openList);
                decimal stdClose = StandardDeviation(closeList);

                Console.WriteLine(values.Key + " had a S.D. for its low of " + stdLow);
                Console.WriteLine(values.Key + " had a S.D. for its high of " + stdHigh);
                Console.WriteLine(values.Key + " had a S.D. for its open of " + stdOpen);
                Console.WriteLine(values.Key + " had a S.D. for its close of " + stdClose);
            }

           
           

        }

        

        public static Dictionary<int, List<DailyQuote>> GroupByYear(List<DailyQuote> quotes)
        {
            Dictionary<int, List<DailyQuote>> yearlyData = new Dictionary<int, List<DailyQuote>>();
            
            for (int i = 0; i < quotes.Count; i++)
            {

                if (yearlyData.ContainsKey(quotes[i].Date.Year))
                {
                    yearlyData[quotes[i].Date.Year].Add(quotes[i]);
                }
                else
                {
                    yearlyData.Add(quotes[i].Date.Year, new List<DailyQuote> { quotes[i] });
                }
            }
            return yearlyData;
        }


        public static decimal StandardDeviation(List<decimal> nums)
        {
            //decimal a = 0;
            //decimal b = 0;
            //int k = 1;


            //foreach(decimal value in nums)
            //{
            //    decimal temp = a;
            //    a += (value * temp) / k;
            //    b += (value - temp) * (value - a);
            //    k++;
            //}
            //return Convert.ToDecimal(Math.Sqrt((double)(b / (k - 2))));


            if (nums.Count < 2) return 0;

            double sumOfSquares = 0;
            decimal avg = nums.Average();
            foreach (decimal value in nums)
            {
                sumOfSquares += Math.Pow((double)(value - avg), 2);
            }
            return Convert.ToDecimal(Math.Sqrt(sumOfSquares / (nums.Count - 1)));


            
        }
    }
}
