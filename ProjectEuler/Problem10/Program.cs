using System;
using System.Collections.Generic;
using Utils;

namespace Problem10
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 2;
            List<int> primes = new List<int>();
            for (int i = 3; i < 2000000; i += 2)
            {
                if (i % 1000 == 1)
                {
                    Console.WriteLine(i);
                }
                if (Util.IsPrimeNumWithList(primes, i))
                {
                    sum += i;
                }
                
            }
            Console.WriteLine(sum);
        }
    }
}
