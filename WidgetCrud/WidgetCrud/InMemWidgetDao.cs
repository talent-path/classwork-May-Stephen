using System;
using System.Collections.Generic;
using System.Linq;

namespace WidgetCrud
{
    public class InMemWidgetDao
    {
        List<Widget> _allWidgets = new List<Widget>();
        int id = 0;

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
            throw new NotImplementedException();
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
            //assuming each page is pageSize wide, return the pageNumberth page of widgets
            //order by name?

            throw new NotImplementedException();
        }
    }
}
