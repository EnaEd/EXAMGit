using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C____Exam
{
    //
    [Serializable]
    public enum DishType { Hot,Cold,Dessert}   
    [Serializable]
     class Dish:ICloneable
    {
        //field
        double price;
        //DishType type;

        //auto properties
       public string Name { get; set; }
       public double Price {
            get {
                return price;
            }
            set {
                if (value > 0){
                    price = value;
                }
                else {
                    throw new Exception("price must be > 0");
                }
            } }
       public DishType Type { get; set; }
        //default constructor
        public Dish() {
            Name = "coffee";
            Price = 3.02;
            Type = DishType.Hot;            
        }
        //override const
        public Dish(string name, double price, DishType type):base() {
            if (name != null || name.Length < 2)
            {
                Name = name;
                Price = price;
                Type = type;
            }
            else{
               
                throw new Exception("wrong name");
            }
            if (Name.Length<2) {
                MessageBox.Show("wrong name,name set is default", "WARNING", MessageBoxButtons.OK);
                Name="coffee";
            }
            
                          
        }
        //destructor
        ~Dish() { }
        //method for view on display
        public override string ToString()
        {
            return String.Format("\t\t Have a good day\n\t Dish\n type:{2}\n name:{0}\nprice:{1}",Name,Price,Type);
        }
        //copy const
        public object Clone()
        {
            Dish dish = new Dish();
            return (object)dish;
            
        }
        //reload operators
        public static Dish operator +(Dish left,double rigth) {
            left.Price += rigth;
            return left;
                }
        public static Dish operator -(Dish left, double rigth)
        {
            left.Price -= rigth;
            return left;
        }
        public static explicit operator long(Dish left)
        {
            if (left.Price - (long)left.Price > 0)
                left.Price =(long)left.Price + 1;
            return (long)left.price;
        }
    }
}
