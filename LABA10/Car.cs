using System;
using System.Collections;
using System.Collections.Generic;

namespace LABA10
{
    public class Car : IInit, IComparable, ICloneable
    {
        public class IdNumber
        {
            // Поля
            private int number;
            // Свойства
            public int Number
            {
                get
                {
                    return number;
                }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Number не может быть меньше 0.");
                        number = 0;
                    }
                    else
                    {
                        number = value;
                    }
                }
            }
            // Конструкторы
            public IdNumber()
            {
                Number = 0;
            }
            public IdNumber(int n)
            {
                Number = n;
            }
            public IdNumber(IdNumber other)
            {
                Number = other.Number;
            }
            // Методы
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                IdNumber other = (IdNumber)obj;
                return Number == other.Number;
            }
            public override string ToString()
            {
                return Number.ToString();
            }
        }
        // ДСЧ
        public static Random rnd = new Random();
        // Поля
        protected string brand;
        protected int year;
        protected string color;
        protected int price;
        protected int gClearance;
        // Свойства
        public string Brand { get; set; }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value >= 1885 && value <= DateTime.Now.Year)
                    year = value;
                else
                {
                    Console.WriteLine("Год выпуска должен быть в диапазоне от 1885 до текущего года.");
                    year = 1885;
                }
            }
        }
        public string Color { get; set; }
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value >= 0)
                    price = value;
                else
                {
                    Console.WriteLine("Цена не может быть отрицательной.");
                    price = 0;
                }
            }
        }
        public int GClearance
        {
            get
            {
                return gClearance;
            }
            set
            {
                if (value > 0)
                    gClearance = value;
                else
                {
                    Console.WriteLine("Дорожный просвет должен быть больше нуля.");
                    gClearance = 1;
                }
            }
        }
        // Конструкторы
        public Car()
        {
            Brand = "Нет бренда";
            Year = 1885;
            Color = "Нет цвета";
            Price = 0;
            GClearance = 1;
        }
        public Car(string b, int y, string c, int p, int gc)
        {
            Brand = b;
            Year = y;
            Color = c;
            Price = p;
            GClearance = gc;
        }
        public Car(Car other)
        {
            Brand = other.Brand;
            Year = other.Year;
            Color = other.Color;
            Price = other.Price;
            GClearance = other.GClearance;
        }
        // Методы
        public virtual void ShowVirt()
        {
            Console.WriteLine($"Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price} руб., Дорожный просвет: {GClearance} мм");
        }
        public void ShowReg()
        {
            Console.WriteLine($"Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price} руб., Дорожный просвет: {GClearance} мм");
        }
        public override string ToString()
        {
            return $"Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price} руб., Дорожный просвет: {GClearance} мм";
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите бренд:");
            Brand = Console.ReadLine();

            Console.WriteLine("Введите год выпуска:");
            Year = VHS.Input("Год должен быть в пределах от 1885 до текущего.", 0, 100000000);

            Console.WriteLine("Введите цвет:");
            Color = Console.ReadLine();

            Console.WriteLine("Введите стоимость:");
            Price = VHS.Input("Цена не может быть отрицательной.", 0, 100000000);

            Console.WriteLine("Введите дорожный просвет:");
            GClearance = VHS.Input("Дорожный просвет может быть от 1 до 400 мм.", 1, 400);
        }
        public virtual void IRandomInit()
        {
            string[] brands = { "Toyota", "Honda", "Ford", "BMW", "Mercedes-Benz", "Audi", "Volkswagen", "Chevrolet", "Hyundai", "Nissan" };
            string[] colors = { "Красный", "Синий", "Зеленый", "Желтый", "Черный", "Белый", "Оранжевый", "Фиолетовый", "Розовый", "Серый" };
            Brand = brands[rnd.Next(10)];
            Year = rnd.Next(1885, DateTime.Now.Year);
            Color = colors[rnd.Next(10)];
            Price = rnd.Next(0, 10000000);
            GClearance = rnd.Next(1, 400);
        }
        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not Car) return -1;
            Car other = obj as Car;
            return String.Compare(this.Brand, other.Brand);
        }
        public virtual object Clone()
        {
            return new Car(this.Brand, this.Year, this.Color, this.Price, this.gClearance);
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            Car other = (Car)obj;
            return Brand == other.Brand && Year == other.Year && Color == other.Color && Price == other.Price && GClearance == other.GClearance;
        }
    }
}
