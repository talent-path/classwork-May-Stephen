using System;
using System.IO;

namespace Problem11
{
    class Program
    {
        static void Main(string[] args)
        {
            string row = "";

            int[,] grid = new int[20, 20];
            int rowIndex = 0;

            using (StreamReader reader = new StreamReader("../../ProjEul11.txt"))
            {
                while ((row = reader.ReadLine()) != null)
                {

                    string[] lineNums = row.Split(" ");
                    for(int i = 0; i < lineNums.Length; i++)
                    {
                        int num = int.Parse(lineNums[i]);
                        grid[rowIndex, i] = num;
                    }

                    rowIndex++;
                    
                }

                Console.WriteLine("Max value is " + ProductOfFour(grid));
            }

            static int ProductOfFour(int[,] grid)
            {
                int a, b, c, d = 0;
                int maxValue = 0;
                for (int i = 0; i < 17; i++)
                {
                    for (int j = 0; j < 17; j++)
                    {
                        a = grid[i, j];
                        b = grid[i, j + 1];
                        c = grid[i, j + 2];
                        d = grid[i, j + 3];

                        int horizontalProd = (a * b * c * d);

                        a = grid[i, j];
                        b = grid[i + 1, j];
                        c = grid[i + 2, j];
                        d = grid[i + 3, j];

                        int verticalProduct = (a * b * c * d);

                        int leftDiagProduct = 0;
                        if ( j >= 3 )
                        {
                            a = grid[i, j];
                            b = grid[i + 1, j - 1];
                            c = grid[i + 2, j - 2];
                            d = grid[i + 3, j - 3];

                            leftDiagProduct = (a * b * c * d);


                        }

                        a = grid[i, j];
                        b = grid[i + 1, j + 1];
                        c = grid[i + 2, j + 2];
                        d = grid[i + 3, j + 3];
                        int rightDiagProduct = (a * b * c * d);

                        maxValue =
                            Math.Max(
                                Math.Max(
                                    (Math.Max(horizontalProd, verticalProduct)),
                                    Math.Max(leftDiagProduct, rightDiagProduct)
                                ),
                                maxValue
                                );
                    }
                }
                return maxValue;
            }
        }
    }
}
