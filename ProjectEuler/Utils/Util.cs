using System;
using System.Numerics;

namespace Utils
{
    public static class Util
    {
        public static bool IsPrimeNum(BigInteger num)
        {
            bool prime = true;
            BigInteger sqrRoot = GetSquareRoot(num);
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

        public static BigInteger GetSquareRoot(BigInteger num)
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
    }
}
