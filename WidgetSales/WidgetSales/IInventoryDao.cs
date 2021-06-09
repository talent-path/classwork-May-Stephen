using System;
namespace WidgetSales
{
    public interface IInventoryDao
    {
        int Add(WidgetInventory toAdd);

        WidgetInventory GetByName(string name);

        void RemoveWidgetByName(string widgetNameToRemove);

        void EditWidget(WidgetInventory toEdit);


    }
}
