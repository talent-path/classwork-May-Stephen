using System;
using System.Collections.Generic;
using System.Numerics;

namespace Utils
{
    public static class Util
    {
        public static bool BigIntIsPrimeNum(BigInteger num)
        {
            bool prime = true;
            BigInteger sqrRoot = BigIntGetSquareRoot(num);
            if (num % 2 == 0)
            {
                return num == 2;
            }
            for (BigInteger check = 3; check <= sqrRoot; check += 2)
            {
                if (num % check == 0)
                {
                    prime = false;
                    break;
                }
            }


            return prime;
        }

        public static bool IsPrimeNum(int num)
        {
            bool prime = true;
            int sqrRoot = GetSquareRoot(num);
            if (num % 2 == 0)
            {
                return num == 2;
            }
            for (int check = 3; check <= sqrRoot; check += 2)
            {
                if (num % check == 0)
                {
                    prime = false;
                    break;
                }
            }


            return prime;
        }

        public static bool IsPrimeNumWithList(List<int> primes, int num)
        {
            foreach ( int prime in primes)
            {
                if (GetSquareRoot(num) > prime)
                    break;
                if( null% prime == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static BigInteger BigIntGetSquareRoot(BigInteger num)
        {
            BigInteger squareRoot = 0;

            for (BigInteger check = 1; check < num / 2; check++)
            {
                if ((check * check) > num)
                {
                    squareRoot = check - 1;
                    break;
                }
            }


            return squareRoot;
        }

        public static int GetSquareRoot(int num)
        {
            int squareRoot = 0;

            for (int check = 1; check < num / 2; check++)
            {
                if ((check * check) > num)
                {
                    squareRoot = check - 1;
                    break;
                }
            }


            return squareRoot;
        }

        public static bool IsPalindrome(int num)
        {

            int temp = num;
            int sum = 0;


            while (num > 0)
            {
                int rem = num % 10;
                num = num / 10;
                sum = sum * 10 + rem;
            }

            if (sum == temp)
            {
                return true;
            }

            return false;
        }

        //public static bool EvenlyDivis(int min, int max, int num)
        //{
        //    for (int div = min; div <= max; div++)
        //    {
        //        bool evenDiv = false;
        //        if (num % div != 0)
        //        {
        //            return false;
        //        }
                

        //    }

        //}

        public static List<long> GetFactors(long num)
        {
            List<long> factors = new List<long>();
            factors.Add(1L);
            factors.Add(num);
            for (long i = 1; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    factors.Add(i);
                    if (i * i != num)
                    {
                        factors.Add(num / i);
                    }

                    
                }
            }
            return factors;
        }
    }
}
