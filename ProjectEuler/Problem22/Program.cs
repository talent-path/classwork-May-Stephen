using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem22
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader reader = new StreamReader("../../../names.txt"))
            {
                long answer = 0;
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
                List<string> names = new List<string>();

                string[] arr = text.Split(',');

                names.AddRange(arr.Select(n => n.Replace("\"", "")));

                names.Sort();

                for (int i = 0; i < names.Count; i++)
                {
                    int score = GetNameScore(names[i]);
                    score *= (i + 1);
                    answer += score;
                }

                Console.WriteLine(answer);
            }
        }

        private static int GetNameScore(string name)
        {
            int sum = name.Select(x => x - 'A' + 1).Sum();
            return sum;
        }
    }
}
