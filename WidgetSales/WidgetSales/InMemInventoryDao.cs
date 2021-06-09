using System;
using System.Linq;
using System.Collections.Generic;

namespace WidgetSales
{
    public class InMemInventoryDao : IInventoryDao
    {
        List<WidgetInventory> _allInventories = new List<WidgetInventory>();

        public InMemInventoryDao()
        {
        }

        public int Add(WidgetInventory toAdd)
        {
            if (toAdd == null)
            {
                throw new ArgumentNullException();
            }
                toAdd.Id = _allInventories.Count + 1;
            _allInventories.Add(new WidgetInventory(toAdd));
            
            return toAdd.Id;
        }

        public WidgetInventory GetByName(string name)
        {
            WidgetInventory nameToGet = _allInventories.SingleOrDefault(w => w.Name == name);

            if (nameToGet == null)
            {
                throw new ItemNotFoundException("Can't find widget with that name.");
            }
            else
            {
                return nameToGet;
            }
        }


        public void RemoveWidgetByName(string toRemove)
        {
            if (toRemove == null)
            {
                throw new ArgumentNullException();
            }

            _allInventories = _allInventories.Where(w => w.Name != toRemove).ToList();
            
        }

        public int CountWidgets()
        {
            return _allInventories.Count;
        }

        public void EditWidget(WidgetInventory toEdit)
        {
            if (toEdit == null)
            {
                throw new ArgumentNullException();
            }
            // change toEdit to new WidgetInventory(toEdit) after test   
            _allInventories = _allInventories.Select(w => w.Id == toEdit.Id ? new WidgetInventory(toEdit) : w).ToList();
        }

        
    }
}
