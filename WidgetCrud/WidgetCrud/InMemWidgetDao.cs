using System;
using System.Collections.Generic;
using System.Linq;

namespace WidgetCrud
{
    public class InMemWidgetDao
    {
        List<Widget> _allWidgets = new List<Widget>
        {
            new Widget { Id = 1, Name="Bread", Category="Food", Price=2.00m},
            new Widget { Id = 2, Name="Milk", Category="Food", Price=1.00m},
            new Widget { Id = 3, Name="Shirt", Category="Clothing", Price=15.00m},
            new Widget { Id = 4, Name="Laptop", Category="Electronics", Price=800.00m},
        };


        int id = 4;

        public InMemWidgetDao()
        {
        }


        public int AddWidget( Widget toAdd)
        {
            Console.WriteLine("Add a new widget.");
            Console.WriteLine("Name: ");
            toAdd.Name = Console.ReadLine();
            Console.WriteLine("Category: ");
            toAdd.Category = Console.ReadLine();
            Console.WriteLine("Price: ");
            toAdd.Price = decimal.Parse(Console.ReadLine());
            id++;
            toAdd.Id = id;
            _allWidgets.Add(toAdd);
            return toAdd.Id;
        }

        public void RemoveWidgetById( int id)
        {
            var toRemove = _allWidgets.RemoveAll(x => x.Id == id);

        }

        public void UpdateWidget( Widget updated)
        {
            Console.WriteLine("Enter the ID for the widget you would like to update: ");
            updated.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new name: ");
            updated.Name = Console.ReadLine();

            Console.WriteLine("Enter the new category: ");
            updated.Category = Console.ReadLine();

            Console.WriteLine("Enter the new price: ");
            updated.Price = decimal.Parse(Console.ReadLine());

            foreach( Widget w in _allWidgets)
            {
                if (w.Id == updated.Id)
                {
                    w.Name = updated.Name;
                    w.Category = updated.Category;
                    w.Price = updated.Price;
                }
            }

        }

        public Widget GetWidgetById( int id)
        {
            Widget toReturn = _allWidgets.FirstOrDefault(x => x.Id == id);
            return toReturn;
        }

        public IEnumerable<Widget> GetWidgetsByCategory( string category)
        {
            var toReturn = _allWidgets.Where(x=> x.Category == category);
            return toReturn;

            
        }

        public IEnumerable<Widget> GetAllWidgetsForPage( int pageSize, int pageNumber)
        {
            var ascWidgets = _allWidgets.OrderBy(x => x.Id);
            IEnumerable<Widget> page = ascWidgets.Skip((pageNumber - 1) * pageSize).Take(pageSize);

          
            return page;
        }
    }
}
