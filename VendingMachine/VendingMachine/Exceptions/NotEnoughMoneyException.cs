using System;
namespace VirtualVendingMachine.Exceptions
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException(string msg) : base(msg)
        {
        }

        public NotEnoughMoneyException(string msg, Exception e) : base(msg, e)
        {

        }
    }
}
