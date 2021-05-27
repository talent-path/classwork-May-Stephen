using System;
using System.Collections.Generic;
using Utils;

namespace Problem12
{
    class Program
    {
        static void Main(string[] args)
        {

            long curr = 1;
            long i = 2;
            while(Util.GetFactors(curr).Count<500)
            {
                curr += i;
                i++;
            }

            Console.WriteLine(curr);
        }
    }
}
