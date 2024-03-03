using LABA10;
using Main;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using static LABA10.Car;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Car Tests
        [TestMethod]
        public void TestDefaultConstructor()
        {
            // Arrange
            Car car = new Car();

            // Act
            string brand = car.Brand;
            int year = car.Year;
            string color = car.Color;
            int price = car.Price;
            int gClearance = car.GClearance;

            // Assert
            Assert.AreEqual("Нет бренда", brand);
            Assert.AreEqual(1885, year);
            Assert.AreEqual("Нет цвета", color);
            Assert.AreEqual(0, price);
            Assert.AreEqual(1, gClearance);
        }

        [TestMethod]
        public void TestParameterizedConstructor()
        {
            // Arrange
            string brand = "Toyota";
            int year = 2020;
            string color = "Red";
            int price = 25000;
            int gClearance = 150;

            // Act
            Car actual = new Car(brand, year, color, price, gClearance);

            // Assert
            Assert.AreEqual(brand, actual.Brand);
            Assert.AreEqual(year, actual.Year);
            Assert.AreEqual(color, actual.Color);
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(gClearance, actual.GClearance);
        }
        [TestMethod]
        public void TestCopyConstructor()
        {
            // Arrange
            string brand = "Toyota";
            int year = 2020;
            string color = "Red";
            int price = 25000;
            int gClearance = 150;
            Car expected = new Car(brand, year, color, price, gClearance);

            // Act

            Car actual = new Car(expected);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestYearOutOfRange()
        {
            // Arrange
            int expected = 1885;

            // Act
            Car actual = new Car();
            actual.Year = 1884;

            // Assert
            Assert.AreEqual(expected, actual.Year);
        }

        [TestMethod]
        public void TestNegativePrice()
        {
            // Arrange
            int expected = 0;

            // Act
            Car actual = new Car();
            actual.Price = -1050;

            // Assert
            Assert.AreEqual(expected, actual.Price);
        }

        [TestMethod]
        public void TestNegativeClearance()
        {
            // Arrange
            int expected = 1;

            // Act
            Car actual = new Car();
            actual.GClearance = -50;

            // Assert
            Assert.AreEqual(expected, actual.GClearance);
        }

        [TestMethod]
        public void TestClone()
        {
            // Arrange
            Car expected = new Car("Toyota", 2020, "Red", 25000, 150);

            // Act
            Car actual = (Car)expected.Clone();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCompareTo0()
        {
            // Arrange
            int expected = 0;

            // Act
            Car car = new Car("Toyota", 2020, "Red", 25000, 150);
            int actual = car.CompareTo(new Car("Toyota", 1990, "", 100, 100));

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCompareToM1()
        {
            // Arrange
            int expected = -1;

            // Act
            Car car = new Car("Audi", 2020, "Red", 25000, 150);
            int actual = car.CompareTo(new Car("Toyota", 1990, "", 100, 100));

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCompareTo1()
        {
            // Arrange
            int expected = 1;

            // Act
            Car car = new Car("BMW", 2020, "Red", 25000, 150);
            int actual = car.CompareTo(new Car("Audi", 1990, "", 100, 100));

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestShallowCopy()
        {
            // Arrange
            Car expected = new Car();

            // Act
            Car actual = (Car)expected.ShallowCopy();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        // IdNumber Tests
        [TestMethod]
        public void TestIdNumberInitialization()
        {
            // Arrange
            int expected = 12345;

            // Act
            IdNumber actual = new IdNumber(expected);

            // Assert
            Assert.AreEqual(expected, actual.Number);
        }

        [TestMethod]
        public void TestIdNumberEquals()
        {
            // Arrange
            IdNumber idNumber1 = new IdNumber(12345);
            IdNumber idNumber2 = new IdNumber(12345);
            IdNumber idNumber3 = new IdNumber(54321);

            // Act & Assert
            Assert.AreEqual(idNumber1, idNumber2);
            Assert.AreNotEqual(idNumber1, idNumber3);
        }
        [TestMethod]
        public void TestIdNumberConstructorWithNegativeNumber()
        {
            // Arrange
            int expected = 0;

            // Act
            IdNumber actual = new IdNumber(-123);

            // Assert
            Assert.AreEqual(expected, actual.Number);
        }
        [TestMethod]
        public void TestIdNumberEmptyAndCopyConstructors()
        {
            // Arrange
            IdNumber expected = new IdNumber();

            // Act
            IdNumber actual = new IdNumber(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        // PassengerCar Tests
        [TestMethod]
        public void TestPCDefaultConstructor()
        {
            // Arrange
            PassengerCar car = new PassengerCar();

            // Act
            string brand = car.Brand;
            int year = car.Year;
            string color = car.Color;
            int price = car.Price;
            int gClearance = car.GClearance;
            int seats = car.Seats;
            int maxSpeed = car.MaxSpeed;

            // Assert
            Assert.AreEqual("Нет бренда", brand);
            Assert.AreEqual(1885, year);
            Assert.AreEqual("Нет цвета", color);
            Assert.AreEqual(0, price);
            Assert.AreEqual(1, gClearance);
            Assert.AreEqual(1, seats);
            Assert.AreEqual(1, maxSpeed);
        }

        [TestMethod]
        public void TestPCParameterizedConstructor()
        {
            // Arrange
            string brand = "Toyota";
            int year = 2020;
            string color = "Red";
            int price = 25000;
            int gClearance = 150;
            int seats = 5;
            int maxSpeed = 200;

            // Act
            PassengerCar actual = new PassengerCar(brand, year, color, price, gClearance, seats, maxSpeed);

            // Assert
            Assert.AreEqual(brand, actual.Brand);
            Assert.AreEqual(year, actual.Year);
            Assert.AreEqual(color, actual.Color);
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(gClearance, actual.GClearance);
            Assert.AreEqual(seats, actual.Seats);
            Assert.AreEqual(maxSpeed, actual.MaxSpeed);
        }

        [TestMethod]
        public void TestPCCopyConstructor()
        {
            // Arrange
            string brand = "Toyota";
            int year = 2020;
            string color = "Red";
            int price = 25000;
            int gClearance = 150;
            int seats = 5;
            int maxSpeed = 200;
            PassengerCar expected = new PassengerCar(brand, year, color, price, gClearance, seats, maxSpeed);

            // Act
            PassengerCar actual = new PassengerCar(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPCEquals()
        {
            // Arrange
            PassengerCar car1 = new PassengerCar("Toyota", 2020, "Red", 25000, 150, 5, 200);
            PassengerCar car2 = new PassengerCar("Toyota", 2020, "Red", 25000, 150, 5, 200);
            PassengerCar car3 = new PassengerCar("Audi", 2019, "Blue", 27000, 160, 4, 220);

            // Act & Assert
            Assert.AreEqual(car1, car2);
            Assert.AreNotEqual(car1, car3);
        }
        [TestMethod]
        public void TestPCClone()
        {
            // Arrange
            PassengerCar expected = new PassengerCar();

            // Act
            PassengerCar actual = (PassengerCar)expected.Clone();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPCNegativeSpeed()
        {
            // Arrange
            PassengerCar expected = new PassengerCar();

            // Act
            PassengerCar actual = new PassengerCar(expected);
            actual.MaxSpeed = -9;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPCNegativeSeats()
        {
            // Arrange
            PassengerCar expected = new PassengerCar();

            // Act
            PassengerCar actual = new PassengerCar(expected);
            actual.Seats = -9;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // SUV Tests
        [TestMethod]
        public void TestSUVDefaultConstructor()
        {
            // Arrange
            SUV suv = new SUV();

            // Act
            string brand = suv.Brand;
            int year = suv.Year;
            string color = suv.Color;
            int price = suv.Price;
            int gClearance = suv.GClearance;
            bool allWheelDrive = suv.AllWheelDrive;
            string offRoadType = suv.OffRoadType;

            // Assert
            Assert.AreEqual("Нет бренда", brand);
            Assert.AreEqual(1885, year);
            Assert.AreEqual("Нет цвета", color);
            Assert.AreEqual(0, price);
            Assert.AreEqual(1, gClearance);
            Assert.IsTrue(allWheelDrive);
            Assert.AreEqual("Нет типа", offRoadType);
        }

        [TestMethod]
        public void TestSUVParameterizedConstructor()
        {
            // Arrange
            string brand = "Toyota";
            int year = 2020;
            string color = "Red";
            int price = 25000;
            int gClearance = 150;
            bool allWheelDrive = true;
            string offRoadType = "Sand";

            // Act
            SUV actual = new SUV(brand, year, color, price, gClearance, allWheelDrive, offRoadType);

            // Assert
            Assert.AreEqual(brand, actual.Brand);
            Assert.AreEqual(year, actual.Year);
            Assert.AreEqual(color, actual.Color);
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(gClearance, actual.GClearance);
            Assert.AreEqual(allWheelDrive, actual.AllWheelDrive);
            Assert.AreEqual(offRoadType, actual.OffRoadType);
        }

        [TestMethod]
        public void TestSUVCopyConstructor()
        {
            // Arrange
            string brand = "Toyota";
            int year = 2020;
            string color = "Red";
            int price = 25000;
            int gClearance = 150;
            bool allWheelDrive = true;
            string offRoadType = "Sand";
            SUV expected = new SUV(brand, year, color, price, gClearance, allWheelDrive, offRoadType);

            // Act
            SUV actual = new SUV(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSUVClone()
        {
            // Arrange
            SUV expected = new SUV("Toyota", 2020, "Red", 25000, 150, true, "Sand");

            // Act
            SUV actual = (SUV)expected.Clone();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSUVEquals()
        {
            // Arrange
            SUV suv1 = new SUV("Toyota", 2020, "Red", 25000, 150, true, "Sand");
            SUV suv2 = new SUV("Toyota", 2020, "Red", 25000, 150, true, "Sand");
            SUV suv3 = new SUV("Audi", 2019, "Blue", 27000, 160, false, "Gravel");

            // Act & Assert
            Assert.IsTrue(suv1.Equals(suv2));
            Assert.IsFalse(suv1.Equals(suv3));
        }

        // Truck Tests
        [TestMethod]
        public void TestTruckDefaultConstructor()
        {
            // Arrange
            Truck truck = new Truck();

            // Act
            string brand = truck.Brand;
            int year = truck.Year;
            string color = truck.Color;
            int price = truck.Price;
            int gClearance = truck.GClearance;
            int loadCapacity = truck.LoadCapacity;

            // Assert
            Assert.AreEqual("Нет бренда", brand);
            Assert.AreEqual(1885, year);
            Assert.AreEqual("Нет цвета", color);
            Assert.AreEqual(0, price);
            Assert.AreEqual(1, gClearance);
            Assert.AreEqual(1, loadCapacity);
        }

        [TestMethod]
        public void TestTruckParameterizedConstructor()
        {
            // Arrange
            string brand = "Volvo";
            int year = 2022;
            string color = "Yellow";
            int price = 50000;
            int gClearance = 200;
            int loadCapacity = 10000;

            // Act
            Truck actual = new Truck(brand, year, color, price, gClearance, loadCapacity);

            // Assert
            Assert.AreEqual(brand, actual.Brand);
            Assert.AreEqual(year, actual.Year);
            Assert.AreEqual(color, actual.Color);
            Assert.AreEqual(price, actual.Price);
            Assert.AreEqual(gClearance, actual.GClearance);
            Assert.AreEqual(loadCapacity, actual.LoadCapacity);
        }

        [TestMethod]
        public void TestTruckCopyConstructor()
        {
            // Arrange
            string brand = "Volvo";
            int year = 2022;
            string color = "Yellow";
            int price = 50000;
            int gClearance = 200;
            int loadCapacity = 10000;
            Truck expected = new Truck(brand, year, color, price, gClearance, loadCapacity);

            // Act
            Truck actual = new Truck(expected);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTruckNegativeLoadCapacity()
        {
            // Arrange
            int expected = 1;

            // Act
            Truck actual = new Truck();
            actual.LoadCapacity = -500;

            // Assert
            Assert.AreEqual(expected, actual.LoadCapacity);
        }

        [TestMethod]
        public void TestTruckClone()
        {
            // Arrange
            Truck expected = new Truck("Volvo", 2022, "Yellow", 50000, 200, 10000);

            // Act
            Truck actual = (Truck)expected.Clone();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTruckEquals()
        {
            // Arrange
            Truck truck1 = new Truck("Volvo", 2022, "Yellow", 50000, 200, 10000);
            Truck truck2 = new Truck("Volvo", 2022, "Yellow", 50000, 200, 10000);
            Truck truck3 = new Truck("Scania", 2021, "Red", 60000, 220, 15000);

            // Act & Assert
            Assert.IsTrue(truck1.Equals(truck2));
            Assert.IsFalse(truck1.Equals(truck3));
        }

        // Тесты запросов
        [TestMethod]
        public void TestFindMostExpensiveSUV()
        {
            // Arrange
            Car[] cars = Main.Program.CreateCarsArray();
            SUV expected = cars.OfType<SUV>().OrderByDescending(s => s.Price).FirstOrDefault();

            // Act
            SUV actual = Main.Program.FindMostExpensiveSUV(cars);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAveragePCSpeed()
        {
            // Arrange
            Car[] cars = Main.Program.CreateCarsArray();
            double expected = cars.OfType<PassengerCar>().Average(pc => pc.MaxSpeed);

            // Act
            double actual = Main.Program.AveragePCSpeed(cars);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTruckWithMaxLoadCapacity()
        {
            // Arrange
            Car[] cars = Main.Program.CreateCarsArray();
            Truck expected = cars.OfType<Truck>().OrderByDescending(t => t.LoadCapacity).FirstOrDefault();

            // Act
            Truck actual = Main.Program.TruckWithMaxLoadCapacity(cars);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // SortByYear Tests
        [TestMethod]
        public void TestSBYFirstCarBeforeSecond()
        {
            // Arrange
            int expected = -1;

            // Act
            SortByYear comparer = new SortByYear();
            Car car1 = new Car("Toyota", 2000, "Red", 15000, 150);
            Car car2 = new Car("Honda", 2010, "Blue", 20000, 155);
            int actual = comparer.Compare(car1, car2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSBYFirstCarAfterSecond()
        {
            // Arrange
            int expected = 1;

            // Act
            SortByYear comparer = new SortByYear();
            Car car1 = new Car("Toyota", 2015, "Red", 15000, 150);
            Car car2 = new Car("Honda", 2005, "Blue", 20000, 155);
            int actual = comparer.Compare(car1, car2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSBYCarsHaveSameYear()
        {
            // Arrange
            int expected = 0;

            // Act
            SortByYear comparer = new SortByYear();
            Car car1 = new Car("Toyota", 2010, "Red", 15000, 150);
            Car car2 = new Car("Honda", 2010, "Blue", 20000, 155);
            int actual = comparer.Compare(car1, car2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}