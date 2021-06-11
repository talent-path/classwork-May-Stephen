using System;
using System.Collections.Generic;

namespace VirtualVendingMachine.Models
{
    public interface IVendingMachine
    {
        public List<Snack> Snacks { get; set; }
    }
}
