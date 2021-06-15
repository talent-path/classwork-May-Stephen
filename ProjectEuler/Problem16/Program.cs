using System;
using Utils;

namespace Problem16
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = Util.ToThePowerOf(2, 100);
            

            int[] numArr = new int[] { };

            while (num > 0)
            {
                int digit = num % 10;
                numArr[numArr.Length ] = digit;

                num /= 10;
            }

            int sum = 0;
            for (int i = 0; i < numArr.Length; i++)
            {
                sum += numArr[i];
            }

            Console.WriteLine(sum);
        }
    }
}
