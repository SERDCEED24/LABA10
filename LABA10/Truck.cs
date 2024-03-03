using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA10
{
    public class Truck : Car
    {
        // Поля
        protected int loadCapacity;
        // Свойства
        public int LoadCapacity
        {
            get
            {
                return loadCapacity;
            }
            set
            {
                if (value > 0)
                    loadCapacity = value;
                else
                {
                    Console.WriteLine("Грузоподъёмность должна быть больше 0!");
                    loadCapacity = 1;
                }
            }
        }
        // Конструкторы
        public Truck() : base()
        {
            LoadCapacity = 1;
        }
        public Truck(string b, int y, string c, int p, int gc, int lc) : base(b, y, c, p, gc)
        {
            LoadCapacity = lc;
        }
        public Truck(Truck other) : base(other)
        {
            LoadCapacity = other.LoadCapacity;
        }
        // Методы
        public override void ShowVirt()
        {
            base.ShowVirt();
            Console.WriteLine($"Грузоподъёмность: {LoadCapacity}");
        }
        public void ShowReg()
        {
            base.ShowReg();
            Console.WriteLine($"Грузоподъёмность: {LoadCapacity}");
        }
        public override string ToString()
        {
            return base.ToString() + $", Грузоподъёмность: {LoadCapacity}";
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите грузоподъёмность");
            LoadCapacity = VHS.Input("Грузоподъёмность должна быть больше 0!", 1);
        }
        public override void IRandomInit()
        {
            base.IRandomInit();
            LoadCapacity = rnd.Next(1, 500);
        }
        public override object Clone()
        {
            return new Truck(this.Brand, this.Year, this.Color, this.Price, this.gClearance, this.LoadCapacity);
        }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            Truck other = (Truck)obj;
            return LoadCapacity == other.LoadCapacity;
        }
    }
}
