using System;
using System.Collections.Generic;
using Utils;

namespace Problem24
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allPerms = new List<string>();
            List<string> available = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string currNum = "";

            Util.GeneratePermutations(allPerms, currNum, available);

            Console.WriteLine(allPerms[999999]);
        }

        
    }
}
