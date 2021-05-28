using System;
using System.Collections.Generic;

namespace BellCurveWarmUp
{
    class Program
    {
        static void Main(string[] args)
        {
          

            double[] input1 = new double[200];
            double[] input2 = new double[200];
            /*
             * Generate random number to generate uniform random numbers
             * Sample from a bell curve
             * Mean = 0, StdDev = 1 
             * 
             */
            

            List<double> test = new List<double>();
            for( int i = 0; i < input1.Length; i++)
            {
                GenerateRandomDistribution(input1);
                GenerateRandomDistribution(input2);
                test.Add(BoxMullerTransformation(input1, input2));
            }
            //for (int j = 0; j < test1.Count; j++)
            //{
            //    Console.WriteLine(test1[j]);
            //}

            double mean = CalculateMean(test);
            double stdDev = CalculateStdDev(test);

            Console.WriteLine("Mean: " + mean);
            Console.WriteLine("Standard Deviation: " + stdDev);
        }

        public static double[] GenerateRandomDistribution(double[] test)
        {
            Random rand = new Random();
            
            
            for (int i = 0; i < test.Length; i++)
            {
                double num = rand.NextDouble();
                test[i] = num;

            }
            return test;

        
        }

        public static double BoxMullerTransformation(double[] a, double[] b)
        {
            long count = a.Length <= b.Length ? a.Length : b.Length;

            double normal = 0.0;
            double dub1, dub2;

            for (int i = 0; i < count; i++)
            {
                dub1 = a[i];
                dub2 = b[i];
                if (dub1  < 0 || dub1 > 1 || dub2 < 0 || dub2 > 1)
                {
                    normal = default(double);
                    
                }
                else
                {
                    double sqrt = Math.Sqrt(-2.0 * Math.Log(dub1));
                    double v = 2.0 * Math.PI * dub2;

                    normal = sqrt * Math.Cos(v);
                    
                }
            }
            return normal;

        }

        public static double CalculateMean(List<double> test)
        {
            double sum = 0;
            foreach (double num in test)
            {
                sum += num;
            }

            double mean = sum / test.Count;
            return mean;
        }

        public static double CalculateStdDev(List<double> test)
        {
            if (test.Count < 2) return 0;

            double sumOfSquares = 0;
            double avg = CalculateMean(test);
            foreach (double value in test)
            {
                sumOfSquares += Math.Pow((double)(value - avg), 2);
            }
            return (Math.Sqrt(sumOfSquares / (test.Count - 1)));
        }
    }
}
