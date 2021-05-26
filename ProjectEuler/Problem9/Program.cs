using System;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {
        
            int c = 0;

            int product = 0;

            // a 2 + b 2 = c 2
            // a + b + c = 1000
            // find a * b * c

            for ( int a = 1; a < 1000; a++)
            {
                for (int b = 1; b < 1000; b++)
                {
                    c = 1000 - a - b;
                    if ((a * a) + (b * b) == (c * c))
                    {
                        product = a * b * c;
                        
                    }
                }
            }
            Console.WriteLine(product);
        }
    }
}
