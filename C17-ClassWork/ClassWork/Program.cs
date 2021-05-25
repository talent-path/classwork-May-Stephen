using System;


namespace ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
          // take in user input date
          Console.Write("Please enter a date (yyyy, M/dd): ");
          string userInput = Console.ReadLine();

          // get date of next friday
          DateTime parsedDate = DateTime.ParseExact(userInput, "yyyy, M/dd", null);

          int daysUntilFriday = System.DayOfWeek.Friday - parsedDate.DayOfWeek;
          parsedDate = parsedDate.AddDays(daysUntilFriday); 

          Console.WriteLine(daysUntilFriday + " days until Friday " + parsedDate);
    }
    }
}
