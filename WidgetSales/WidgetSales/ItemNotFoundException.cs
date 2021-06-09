using System;
namespace WidgetSales
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(string msg) : base(msg)
        {
        }

        public ItemNotFoundException(string msg, Exception e) : base(msg, e)
        {

        } 
    }
}
