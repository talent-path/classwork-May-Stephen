using System;
namespace WidgetSales
{
    public class WidgetInventory
    {
        public int Id { get; set; }
        public int StockCount { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }


        public WidgetInventory()
        {
        }

        public WidgetInventory(WidgetInventory toCopy)
        {
            this.Id = toCopy.Id;
            this.Category = toCopy.Category;
            this.Name = toCopy.Name;
            this.StockCount = toCopy.StockCount;
        }
    }
}
