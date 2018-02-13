using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace C____Exam
{
    public enum DayGrad { Morning,Dinner,Evenig}
    class Resto:Menu
    {
       public static int count=0;
        //show menu 
        public static void ShowMenu(Menu left)
        {
            int timeHour = DateTime.Now.Hour;
            switch (timeHour)
            {
                case 0: 
                case 1: 
                case 2: 
                case 3: 
                case 4: 
                case 5: left.Create(left, MenuFlag.All); break;
                case 6: 
                case 7: 
                case 8: 
                case 9: 
                case 10:
                case 11: left.Create(left, MenuFlag.Morning); break;
                case 12: 
                case 13: 
                case 14: 
                case 15: 
                case 16: 
                case 17: left.Create(left, MenuFlag.Dinner); break;
                case 18: 
                case 19: 
                case 20: 
                case 21: 
                case 22: 
                case 23: left.Create(left, MenuFlag.Evening); break;
                default:break;
            }
        }
        //create order
        public static string Order(Menu left,string name) {
            string order="";
            var menufind = from item in left.listMenu
                           where item.Value.Name.Equals(name)
                           select item;
            foreach (var i in menufind)
            {
                order = i.Value.Name.ToString()+":\t "+i.Value.Price.ToString();
            }
            return order;
        }
        //score order
        public static void ScoreOrder(string order) {
            //Console.WriteLine(order.Split(' '));
            string[] score = order.Split(' ');
            double price = Double.Parse(score[1]);
            double sum = 0;
            sum += price;
            Console.WriteLine("\t\tScore\n {0} \t{1}\n \t\t\tTotal: {2}",score[0],score[1],sum);
       
    }
        //check order(change order)
        public static void CheckoutOrder(string order) {
            if (File.Exists(@"G:\Order.txt")){
                count++;
                File.WriteAllText(@"G:\Order" + count + ".txt", order, Encoding.Unicode);
            }
            else
                File.WriteAllText(@"G:\Order.txt", order, Encoding.Unicode);
            

            



        }
        public static void CheckinOrder()
        {
            Console.WriteLine(File.ReadAllText(@"G:\Order.txt"));
        }
        //check order(change menu)
        public static void CheckoutMenu(Menu left) {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"G:\Oreder.dat", FileMode.Create)) {
                bf.Serialize(fs, left.listMenu);
            }
        }
        public static Menu CheckinMenu() {
            Menu CreateMenu;
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"G:\Oreder.dat", FileMode.Open)){
                CreateMenu = (Menu)bf.Deserialize(fs);
            }
            return CreateMenu;
        }
        //create report
        public static void Report() {
            string[] orders=new string[count+1];
            for (int i = 0; i <= count; i++) {
                if(i==0)
                orders[i] = File.ReadAllText(@"G:\Order.txt");
                else
                orders[i]= File.ReadAllText(@"G:\Order"+i+".txt");
            }
            Console.WriteLine("\tReport orders\n");
            foreach (var item in orders)
            {
                Console.WriteLine(item);
            }
        }
        //delete orders
        public static void DeleteOrder() {
            for (int i = 0; i <= count; i++){
                if (i == 0)
                    File.Delete(@"G:\Order.txt");
                else
                    File.Delete(@"G:\Order" + i + ".txt");
            }
        }


    }
}
