using System;
namespace VirtualVendingMachine.Exceptions
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException(string msg) : base(msg)
        {
        }

        public OutOfStockException(string msg, Exception e) : base(msg, e)
        {

        }
    }
}
