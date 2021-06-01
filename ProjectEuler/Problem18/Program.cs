using System;
using System.Collections.Generic;
using System.IO;

namespace Problem18
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("../../../../p067_triangle.txt"))
            {
                
                List<List<int>> outerList = new List<List<int>>();
                string data;
                while ((data = sr.ReadLine()) != null)
                {
                    List<int> innerList = new List<int>();
                    string[] arr = data.Split(' ');
                    foreach(string num in arr)
                    {

                        int newNum = int.Parse(num);
                        innerList.Add(newNum);
                        
                    }
                    outerList.Add(innerList);
                }
               for ( int i = 1; i < outerList.Count; i++)
                {
                    
                    int sum = 0;
                    
                    for ( int j = 0; j < outerList[i].Count; j++)
                    {
                        if (j == 0)
                        {
                            sum = outerList[i][j] + outerList[i - 1][j];
                        }
                        else if (j == outerList[i].Count - 1)
                        {
                            sum = outerList[i][j] + outerList[i - 1][j - 1];
                        }
                        else
                        {
                            sum = outerList[i][j] + Math.Max(outerList[i - 1][j], outerList[i - 1][j - 1]);
                        }

                        outerList[i][j] = sum;
                    }
                }
                int maxSum = 0;
                int lastRow = outerList.Count - 1;
                for ( int i = 0; i < outerList[lastRow].Count; i++)
                {
                    //if (outerList[lastRow][i] > maxSum)
                    //{
                    //    maxSum = outerList[lastRow][i];
                    //}

                    maxSum = Math.Max(maxSum, outerList[lastRow][i]);
                }

                Console.WriteLine(maxSum);

            }



        }
    }
}
