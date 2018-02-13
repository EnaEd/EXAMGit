using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C____Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu test = new Menu();
            test.listMenu.Add(1, new Menu("soup", 4, DishType.Hot, MenuFlag.Dinner));
            test.listMenu.Add(2, new Menu("tea", 2, DishType.Hot, MenuFlag.All));
            test.listMenu.Add(3, new Menu("pasta", 4.32, DishType.Hot, MenuFlag.Dinner));
            test.listMenu.Add(4, new Menu("donat", 1.48, DishType.Dessert, MenuFlag.All));
            test.listMenu.Add(5, new Menu("Coca-cola", 2, DishType.Cold, MenuFlag.All));
            test.listMenu.Add(6, new Menu("eggs", 4, DishType.Hot, MenuFlag.Morning));
            test.Search(test, "eggs");
            test.Search(test, 4);
            test.Search(test, DishType.Hot);
            Menu test2 = new Menu();
            test2.listMenu = test.Create(test, MenuFlag.All);
            Console.WriteLine(DateTime.Now.Hour);
            Resto.ShowMenu(test);
            Console.WriteLine(Resto.Order(test, "donat"));
            Resto.CheckoutOrder(Resto.Order(test, "eggs"));
            Resto.CheckoutOrder(Resto.Order(test, "donat"));
            Resto.CheckoutOrder(Resto.Order(test, "tea"));
            Resto.CheckinOrder();
            Resto.ScoreOrder(Resto.Order(test, "donat"));
            Console.WriteLine(Resto.count);
            Resto.Report();
            Resto.DeleteOrder();




        }
    }
}
