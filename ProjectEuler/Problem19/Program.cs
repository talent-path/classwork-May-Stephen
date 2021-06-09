using System;

namespace Problem19
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstSundays = 0;

            //DateTime start = new DateTime(1901, 1, 1);
            
            ////for (int month = 0; month < 1200; month++ )
            //{
                
                

            //    if (start.DayOfWeek == DayOfWeek.Sunday)
            //    {
            //        firstSundays++;
            //    }
            //    start = start.AddMonths(1);

                
            //}

            for(DateTime current = new DateTime(1901, 1, 1); current <= new DateTime(2000, 12, 1); current = current.AddMonths(1))
            {
                if (current.DayOfWeek == DayOfWeek.Sunday)
                {
                    firstSundays++;
                }
            }

            Console.WriteLine(firstSundays);
            
        }
    }
}
