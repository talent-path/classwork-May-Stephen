using System;
using System.Collections.Generic;
using Utils;

namespace Problem27
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            int maxLength = 0;
            (int, int) coefficients = (0, 0);

            List<int> bPrimes = new List<int>();

            for (int i = 2; i < 1000; i++)
            {
                if(Util.IsPrimeNum(i))
                {
                    bPrimes.Add(i);
                }

                for (int a = -999; a <= 999; a++)
                {
                    foreach (int b in bPrimes )
                    {
                        bool foundNonPrime = false;
                        int count = 0;
                        while(!foundNonPrime)
                        {
                            if (Util.IsPrimeNum(n * n + a * n + b))
                            {
                                count++;
                            }
                            else foundNonPrime = true;

                            n++;
                        }

                        

                        if(maxLength < count)
                        {
                            coefficients = (a, b);
                            maxLength = count;
                        }
                    }
                }

                
            }

            Console.WriteLine(coefficients.Item1 * coefficients.Item2);
        }
    }
}
