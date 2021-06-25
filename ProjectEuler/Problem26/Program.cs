using System;
using System.Collections.Generic;



namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxDen = 2;
            int maxCycle = 0;
            for (int den = 2; den < 1000; den++)
            {
                HashSet<int> remainders = new HashSet<int>();
                int remain = 1;
                while (remain != 0)
                {
                    int val = remain / den;
                    remain = (remain - (den * val)) * 10;
                    if (!remainders.Add(remain))
                    {
                        if (remainders.Count > maxCycle)
                        {
                            maxCycle = remainders.Count;
                            maxDen = den;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine($"Max denominator is {maxDen}");



        }



    }
}