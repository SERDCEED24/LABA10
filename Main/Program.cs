using LABA10;
using System.Collections.Immutable;
using System.Runtime.InteropServices;

namespace Main
{
    public class Program
    {
        public static Car[] CreateCarsArray()
        {
            // Массив для хранения машин
            Car[] cars = new Car[20];
            // Создаём 5 объектов класса Car
            for (int i = 0; i < 5; i++)
            {
                cars[i] = new Car();
                cars[i].IRandomInit();
            }
            // Создаём 5 объектов класса PassengerCar
            for (int i = 5; i < 10; i++)
            {
                cars[i] = new PassengerCar();
                cars[i].IRandomInit();
            }
            // Создаём 5 объектов класса SUV
            for (int i = 10; i < 15; i++)
            {
                cars[i] = new SUV();
                cars[i].IRandomInit();
            }
            // Создаём 5 объектов класса Truck
            for (int i = 15; i < 20; i++)
            {
                cars[i] = new Truck();
                cars[i].IRandomInit();
            }
            return cars;
        }
        public static IInit[] CreateAIOArray()
        {
            // Массив для хранения объектов всех классов
            IInit[] arr = new IInit[25];
            // Создаём 5 объектов класса Car
            for (int i = 0; i < 5; i++)
            {
                arr[i] = new Car();
                arr[i].IRandomInit();
            }
            // Создаём 5 объектов класса PassengerCar
            for (int i = 5; i < 10; i++)
            {
                arr[i] = new PassengerCar();
                arr[i].IRandomInit();
            }
            // Создаём 5 объектов класса SUV
            for (int i = 10; i < 15; i++)
            {
                arr[i] = new SUV();
                arr[i].IRandomInit();
            }
            // Создаём 5 объектов класса Truck
            for (int i = 15; i < 20; i++)
            {
                arr[i] = new Truck();
                arr[i].IRandomInit();
            }
            // Создаём 5 объектов класса DialClock
            for (int i = 20; i < 25; i++)
            {
                arr[i] = new DialClock();
                arr[i].IRandomInit();
            }
            return arr;
        }
        public static SUV FindMostExpensiveSUV(Car[] cars)
        {
            SUV mostExpensive = new SUV();
            foreach (var item in cars)
            {
                if (item is SUV)
                {
                    if (item.Price > mostExpensive.Price)
                    {
                        mostExpensive = (SUV)item;
                    }
                }
            }
            return mostExpensive;
        }
        public static double AveragePCSpeed(Car[] cars)
        {
            int k = 0;
            int s = 0;
            foreach (var item in cars)
            {
                PassengerCar pc = item as PassengerCar;
                if (pc != null)
                {
                    k++;
                    s += pc.MaxSpeed;
                }
            }
            return (double)s / k;
        }
        public static Truck TruckWithMaxLoadCapacity(Car[] cars)
        {
            Truck maxtruck = new Truck();
            foreach (var item in cars)
            {
                if (item.GetType() == typeof(Truck))
                {
                    Truck currTruck = (Truck)item;
                    if (currTruck.LoadCapacity > maxtruck.LoadCapacity)
                    {
                        maxtruck = currTruck;
                    }
                }
            }
            return maxtruck;
        }
        static void PrintArray(IComparable[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
        public static void Task1()
        {
            Console.WriteLine();
            // Создаём массив
            Car[] cars = CreateCarsArray();
            // Вывод информации о машинах с помощью обычных ф-ий
            Console.WriteLine("Информация о машинах(с помощью обычных ф-ий):");
            foreach (var car in cars)
            {
                car.ShowReg();
                Console.WriteLine();
            }
            // Вывод информации о машинах с помощью виртуальных ф-ий
            Console.WriteLine("Информация о машинах(с помощью виртуальных ф-ий):");
            foreach (var car in cars)
            {
                car.ShowVirt();
                Console.WriteLine();
            }
        }
        public static void Task2()
        {
            Console.WriteLine();
            // Создаём массив
            Car[] cars = CreateCarsArray();
            // Запрос с использованием is (Самый дорогой внедорожник)
            Console.WriteLine("Самый дорогой внедорожник:");
            SUV me = FindMostExpensiveSUV(cars);
            me.ShowVirt();
            // Запрос с использованием as (Средняя скорость легковых автомобилей)
            Console.WriteLine("Средняя скорость легковых автомобилей:");
            Console.WriteLine($"{AveragePCSpeed(cars)} км/ч");
            // Запрос с использованием typeof (Грузовик с максимальной грузоподъёмностью)
            Console.WriteLine("Грузовик с максимальной грузоподъёмностью:");
            Truck truck = TruckWithMaxLoadCapacity(cars);
            truck.ShowVirt();
            Console.WriteLine();
        }
        public static void Task3()
        {
            // Создаём массив с объектами всех классов и выводим эти объекты на экран
            IInit[] AIO = CreateAIOArray();
            int CountCar = 0;
            int CountPC = 0;
            int CountSUV = 0;
            int CountTruck = 0;
            foreach (var item in AIO)
            {
                if (item is Car) CountCar++;
                if (item is PassengerCar) CountPC++;
                if (item is SUV) CountSUV++;
                if (item is Truck) CountTruck++;
                Console.WriteLine(item); ;
            }
            // Вывод кол-ва созданных обхектов для каждого класса
            Console.WriteLine($"Создано объектов типа Car: {CountCar}");
            Console.WriteLine($"Создано объектов типа PassengerCar: {CountPC}");
            Console.WriteLine($"Создано объектов типа SUV: {CountSUV}");
            Console.WriteLine($"Создано объектов типа Truck: {CountTruck}");
            Console.WriteLine($"Создано объектов типа DialClock: {DialClock.GetCount}\n");
            // Сортировка и поиск
            IComparable[] cars = CreateCarsArray();
            Console.WriteLine("Неотсортированный массив:");
            PrintArray(cars);
            // По названию бренда
            Array.Sort(cars);
            Console.WriteLine("\nОтсортированный массив(по названию бренда):");
            PrintArray(cars);
            int position = Array.BinarySearch(cars, new Car("Ford", 1885, "Чёрный", 1000000, 135));
            Console.WriteLine($"Первая встречающаяся в массиве машина марки Ford находится на {position + 1} месте");
            Console.WriteLine();
            // По году выпуска машины
            cars[4] = new Car("BMW", 1945, "Синий", 10000000, 240);
            Array.Sort(cars, new SortByYear());
            Console.WriteLine("Отсортированный массив(по году выпуска):");
            PrintArray(cars);
            position = Array.BinarySearch(cars, new Car("Ford", 1945, "Чёрный", 1000000, 135), new SortByYear());
            Console.WriteLine($"Первая встречающаяся в массиве машина 1945 года выпуска находится на {position + 1} месте");
            // Клонируем объекты
            Console.WriteLine("Начальный объект:");
            Car NewCar = new Car();
            NewCar.IRandomInit();
            Console.WriteLine(NewCar);
            Console.WriteLine("Его клон:");
            Car NewClone = (Car)NewCar.Clone();
            Console.WriteLine(NewClone);
            Console.WriteLine("Его поверхностная копия:");
            Car NewShallowCopy = (Car)NewCar.ShallowCopy();
            Console.WriteLine(NewShallowCopy);
            // Изменим объект
            Console.WriteLine("Измённый объект:");
            NewCar.Year += 59;
            Console.WriteLine(NewCar);
            Console.WriteLine("Клон:");
            Console.WriteLine(NewClone);
            Console.WriteLine("Поверхностная копия:");
            Console.WriteLine(NewShallowCopy);
        }
        static void Main(string[] args)
        {
            UI.Menu();
        }
    }
}
