using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA10
{
    public class DialClock : IInit
    {
        // ДСЧ
        public static Random rnd = new Random();
        // Подсчёт созданных объектов
        static int count = 0;
        public static int GetCount => count;
        // Поля
        private int hours;
        private int minutes;
        // Свойства
        public int Hours
        {
            get => hours;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Ошибка. Кол-во часов не может быть меньше 0.");
                    hours = 0;
                }
                else hours = value % 24;
            }
        }
        public int Minutes
        {
            get => minutes;
            set
            {
                if (value >= 60)
                {
                    Hours += value / 60;
                    minutes = value % 60;
                }
                else minutes = value;
                if (value < 0)
                {
                    Console.WriteLine("Ошибка. Кол-во минут не может быть меньше 0.");
                    minutes = 0;
                }
            }
        }
        // Конструкторы
        public DialClock()
        {
            Hours = 0;
            Minutes = 0;
            count++;
        }
        public DialClock(int h, int m)
        {
            Hours = h;
            Minutes = m;
            count++;
        }
        public DialClock(DialClock dc)
        {
            Hours = dc.Hours;
            Minutes = dc.Minutes;
            count++;
        }
        // Методы и статические функции
        public virtual void Init()
        {
            Console.WriteLine("Введите часы:");
            Hours = VHS.Input("Кол-во часов должно быть в пределах от 0 до 23 включительно!", 0, 23);

            Console.WriteLine("Введите минуты:");
            Hours = VHS.Input("Кол-во минут должно быть в пределах от 0 до 59 включительно!", 0, 59);
        }
        public virtual void IRandomInit()
        {
            Hours = rnd.Next(0, 23);
            Minutes = rnd.Next(0, 59);
        }
        public void Show()
        {
            Console.WriteLine($"{Hours}:{Minutes}");
        }
        public override string ToString()
        {
            return $"Часы: {Hours}, Минуты: {Minutes}";
        }
        public double AngleBetweenHnM()
        {
            double angle = Math.Abs(30 * this.Hours - 5.5 * this.Minutes) % 360;
            if (angle > (360 - angle))
            {
                return Math.Round(360 - angle, 4);
            }
            else
            {
                return Math.Round(angle, 4);
            }
        }
        public static double AngleBetweenHnMStat(DialClock dc)
        {
            double angle = Math.Abs(30 * dc.Hours - 5.5 * dc.Minutes) % 360;
            if (angle > (360 - angle))
            {
                return Math.Round(360 - angle, 4);
            }
            else
            {
                return Math.Round(angle, 4);
            }
        }
        public static DialClock operator ++(DialClock dc)
        {
            DialClock result = new DialClock(dc);
            result.Minutes++;
            return result;
        }
        public static DialClock operator --(DialClock dc)
        {
            int time = dc.Hours * 60 + dc.Minutes;
            if (time > 0)
            {
                return new DialClock(0, time - 1);
            }
            else
            {
                return new DialClock(23, 59);
            }
        }
        public static DialClock operator +(int mins, DialClock dc)
        {
            DialClock sum = new DialClock(dc);
            sum.Minutes += mins;
            return sum;
        }
        public static DialClock operator +(DialClock dc, int mins)
        {
            DialClock sum = new DialClock(dc);
            sum.Minutes += mins;
            return sum;
        }
        public static DialClock operator -(int mins, DialClock dc)
        {
            int time = mins - (dc.Hours * 60 + dc.Minutes);
            return new DialClock(0, time);
        }
        public static DialClock operator -(DialClock dc, int mins)
        {
            int time = dc.Hours * 60 + dc.Minutes - mins;
            return new DialClock(0, time);
        }
        public static explicit operator bool(DialClock dc)
        {
            return AngleBetweenHnMStat(dc) % 2.5 == 0;
        }
        public static implicit operator int(DialClock dc)
        {
            return dc.Minutes + dc.Hours * 60;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not DialClock) return false;
            return ((DialClock)obj).Hours == this.Hours && ((DialClock)obj).Minutes == this.Minutes;
        }
    }
}
