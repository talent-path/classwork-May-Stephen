using System;
using System.Collections.Generic;

namespace WidgetCrud
{
    class Program
    {
        static InMemWidgetDao dao = new InMemWidgetDao();


        static void Main(string[] args)
        {

            bool done = false;

            while( !done)
            {
                int choice = PrintMainMenu();
              switch( choice)
                {
                    case 1:
                        AddWidget();
                        break;
                    case 2:
                        RemoveWidgetById();
                        break;
                    case 3:
                        EditWidget();
                        break;
                    case 4:
                        GetWidgetById();
                        break;
                    case 5:
                        GetWidgetsByCat();
                        break;
                    case 6:
                        GetWidgetsByPage();
                        break;
                    case 7:
                        done = true;
                        break;

                }
            }
        }

        private static void GetWidgetsByPage()
        {
            Console.WriteLine("How many widgets per page?");
            int pageSize = int.Parse(Console.ReadLine());
            Console.WriteLine("What page would you like to view?");
            int pageNum = int.Parse(Console.ReadLine());
            IEnumerable<Widget> page = dao.GetAllWidgetsForPage(pageSize, pageNum);
            foreach (Widget widget in page)
            {
                Console.WriteLine($"Name: {widget.Name}, Category: {widget.Category}, Price: {widget.Price}");
            }
            Console.WriteLine();
        }

        private static void GetWidgetsByCat()
        {
            Console.WriteLine("Enter the category you would like to search for: ");
            string cat = Console.ReadLine();
            IEnumerable<Widget> widgets = dao.GetWidgetsByCategory(cat);
            foreach(Widget widget in widgets )
            {
                Console.WriteLine($"Name: {widget.Name}, Category: {widget.Category}, Price: {widget.Price}");
            }
            Console.WriteLine();
        }

        private static void GetWidgetById()
        {
            Console.WriteLine("Enter the ID for the widget you would like to retrieve: ");
            int id = int.Parse(Console.ReadLine());
            Widget toReturn = dao.GetWidgetById(id);
            Console.WriteLine($"Name: {toReturn.Name}");
            Console.WriteLine($"Category: {toReturn.Category}");
            Console.WriteLine($"Price: {toReturn.Price}");
            Console.WriteLine();
        }

        private static void EditWidget()
        {
            Widget widget = new Widget();
            dao.UpdateWidget(widget);
            Console.WriteLine("Widget updated.");
            Console.WriteLine();
        }

        private static void RemoveWidgetById()
        {
            Console.WriteLine("Remove a widget.");
            Console.WriteLine("Provide the ID of the widget you want to remove: ");
            int id = int.Parse(Console.ReadLine());
            dao.RemoveWidgetById(id);
            Console.WriteLine($"Widget {id} removed.");
            Console.WriteLine();
        }

        private static int AddWidget()
        {
            Widget toAdd = new Widget();
            dao.AddWidget(toAdd);
            Console.WriteLine($"Widget {toAdd.Id} created.");
            Console.WriteLine();
            return toAdd.Id;
        }

        private static int PrintMainMenu()
        {
            Console.WriteLine("Welcome, use the following options for command you want to execute: ");
            Console.WriteLine("1: Add a widget. \n" +
                "2: Remove by ID \n" +
                "3: Edit a widget \n" +
                "4: Get widget by Id \n" +
                "5: Get widgets by category \n" +
                "6: Get widgets by page \n" +
                "7: Exit");
            int choice = int.Parse(Console.ReadLine());
            return choice;

        }
    }
}
