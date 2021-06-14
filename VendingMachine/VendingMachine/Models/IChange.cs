using System;
using System.Collections.Generic;
using VirtualVendingMachine.Enums;

namespace VirtualVendingMachine.Models
{
    public interface IChange
    {
        public Dictionary<Coins, int> Money { get; }

    }
}
