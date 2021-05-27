using System;
namespace NasdaqReader
{
    public class DailyQuote
    {

        // DateTime Date
        // decimal Close
        // ulong Volume
        // decimal Open
        // decimal High
        // decimal Low

        public DateTime Date { get; }
        public decimal Close { get; }
        public ulong Volume { get; }
        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }

        public DailyQuote(DateTime date,
            decimal close,
            ulong volume,
            decimal open,
            decimal high,
            decimal low )
        {
            this.Date = date;
            this.Close = close;
            this.Volume = volume;
            this.Open = open;
            this.High = high;
            this.Low = low;
        }

        public DailyQuote(string line)
        {
            string[] cells = line.Split(',');



            Date = Convert.ToDateTime(cells[0]);
            Close = Convert.ToDecimal(cells[1].Remove(0, 1));
            Volume = Convert.ToUInt64(cells[2]);
            Open = Convert.ToDecimal(cells[3].Remove(0, 1));
            High = Convert.ToDecimal(cells[4].Remove(0, 1));
            Low = Convert.ToDecimal(cells[5].Remove(0, 1));
        }

    }
}
