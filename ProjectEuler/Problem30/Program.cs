using System;

namespace Problem30
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int currSum = 0;
            
            for(int curr = 10; curr < 999999; curr++)
            {
                currSum = 0;
                int copy = curr;
                while (copy != 0)
                {
                    
                    int d = copy % 10;
                    int fifth = d * d * d * d * d;
                    currSum += fifth;

                    
                    copy /= 10;
                    
                }

                if (currSum == curr)
                {
                    sum += currSum;
                    Console.WriteLine(sum);
                }

            }

            Console.WriteLine(sum);
        }
    }
}
