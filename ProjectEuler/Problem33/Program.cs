using System;
using Utils;

namespace Problem33
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNum = 1;
            int totalDen = 1;
            for (int num = 10; num < 100; num++)
            {
                for (int den = num + 1; num < 100; num++)
                {
                    int right = num % 10;
                    int left = num / 10;
                    int rightDen = den % 10;
                    int leftDen = den / 10;
                    int a = 0;
                    int b = 0;
                    if (right == rightDen)
                    {
                        a = left;
                        b = leftDen;
                    }
                    if (left == leftDen)
                    {
                        a = right;
                        b = rightDen;
                    }
                    if (left == rightDen)
                    {
                        a = right;
                        b = leftDen;
                    }
                    if (right == leftDen)
                    {
                        a = left;
                        b = rightDen;
                    }
                    if (b != 0 && a != 0 && EqualFractions(a, b, num, den))
                    {
                        totalNum *= num;
                        totalDen *= den;
                    }
                }
            }
            int answer = Util.GreatestCommonDenom(totalNum, totalDen);
            Console.WriteLine(totalDen / answer);
        }
        public static bool EqualFractions(int a, int b, int c, int d)
        {
            return a * d == b * c;
        }
    }
}