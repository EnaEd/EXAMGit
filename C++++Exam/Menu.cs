using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace C____Exam
{
    [Serializable]
    public enum MenuFlag { All,Morning,Dinner,Evening}
    [Serializable]
       class Menu : Dish
    {
        //new field
        public MenuFlag FlagMenu{get;set;}
        //default const
        public Menu() : base() {
            FlagMenu = MenuFlag.All;
        }
        //reload const
        public Menu(string name, double price, DishType type, MenuFlag flag) : base(name, price, type) {
            FlagMenu = flag;
        }
        public override string ToString()
        {
            return String.Format("time menu:{0}\n\n",FlagMenu)+base.ToString();
        }
        //nonsize struct
        //public Dictionary<MenuFlag,Dish> listMenu = new Dictionary<MenuFlag, Dish>();
        public Dictionary<int, Menu> listMenu = new Dictionary<int, Menu>();

        //save in file using serialization
        public void Save(Menu left){
            #region Save with help XML Serialization
            ////not work because non public classes and class have Dictionary<>
            //FileStream fs = new FileStream(@"G:\SaveFile.XML", FileMode.Create);
            //XmlSerializer xs = new XmlSerializer(typeof(Menu));
            //xs.Serialize(fs,left);
            //fs.Close();
            #endregion
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"G:\SaveFile.dat", FileMode.OpenOrCreate)) {
                bf.Serialize(fs, left);
               // Console.WriteLine("serialize complite");
            }

        }
        //Read from file
        public Menu Read() {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(@"G:\SaveFile.dat", FileMode.Open)) {
                Menu ConvertFile = (Menu)formatter.Deserialize(fs);
                //Console.WriteLine("complite");
                return ConvertFile;
            }
        }
        //search data
        public void Search(Menu left,string name) {
            var menufind = from item in left.listMenu
                           where item.Value.Name.Equals(name)
                           select item;
            foreach (var i in menufind){
                Console.WriteLine(i.Value);
            }
        }
        public void Search(Menu left, double price)
        {
            var menufind = from item in left.listMenu
                           where item.Value.Price==price
                           select item;
            foreach (var i in menufind)
            {
                Console.WriteLine(i.Value);
            }
        }
        public void Search(Menu left, DishType type)
        {
            var menufind = from item in left.listMenu
                           where item.Value.Type==type
                           select item;
            foreach (var i in menufind)
            {
                Console.WriteLine(i.Value);
            }
        }
        //create menu with parameters
        public Dictionary<int,Menu> Create( Menu left,MenuFlag flag) {
            Dictionary<int, Menu> newDict = new Dictionary<int, Menu>();
            var menuCreate = from i in left.listMenu
                             where i.Value.FlagMenu.Equals(flag)
                             select i;
            foreach (var item in menuCreate)
            {
                newDict.Add(item.Key,item.Value);
                Console.WriteLine(item.Value);
            }
            return newDict;
            
        }


    }
}
