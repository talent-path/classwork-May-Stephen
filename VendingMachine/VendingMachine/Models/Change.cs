using System;
using System.Collections.Generic;
using VirtualVendingMachine.Enums;

namespace VirtualVendingMachine.Models
{
    public class Change : IChange
    {

        public Change(int numOfPennies)
        {
            if (numOfPennies >= 100)
            {
                int num = numOfPennies / 100;
                Money[Coins.Dollar] = num;
                numOfPennies -= (num * 100);
            }

            if (numOfPennies >= 25)
            {
                int num = numOfPennies / 25;
                Money[Coins.Quarter] = num;
                numOfPennies -= (num * 25);
            }

            if (numOfPennies >= 10)
            {
                int num = numOfPennies / 10;
                Money[Coins.Dime] = num;
                numOfPennies -= (num * 10);
            }

            if (numOfPennies >= 5)
            {
                int num = numOfPennies / 5;
                Money[Coins.Nickel] = num;
                numOfPennies -= (num * 5);
            }

            if (numOfPennies >= 1)
            {
                int num = numOfPennies / 1;
                Money[Coins.Penny] = num;
                numOfPennies -= (num * 1);
            }
        }

        public int this[Coins c]
        {
            get { return Money[c]; }
        }

        public Dictionary<Coins, int> Money { get; } = new Dictionary<Coins, int>()
        {
            {Coins.Dollar, 0 },
            {Coins.Quarter, 0 },
            {Coins.Dime, 0 },
            {Coins.Nickel, 0 },
            {Coins.Penny, 0 }
        };

        
    }
}
