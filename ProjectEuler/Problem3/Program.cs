using System;
using System.Collections.Generic;
using System.Numerics;
using Utils;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {

            BigInteger input = 600851475143;
            //List<BigInteger> primeList = new List<BigInteger> { };

            BigInteger sqrRoot = Util.GetSquareRoot(input);

            BigInteger biggestPrime = -1;

            bool foundBigPrime = false;

            for (BigInteger factor = 1; factor <= sqrRoot; factor++)
            {
                if ( input % factor == 0 )
                {
                    BigInteger newFactor = input / factor;
                    if (Util.IsPrimeNum(newFactor))
                    {
                        Console.WriteLine(newFactor);
                        foundBigPrime = true;
                    }
                    else if (Util.IsPrimeNum(factor) && factor > biggestPrime)
                    {
                        biggestPrime = factor;
                    }


                }
            }
            if(!foundBigPrime)
            {
                Console.WriteLine(biggestPrime);
            }
            
        }
    }
}
