using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_ThucHanh
{
    class Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
    }

    class Car : Vehicle
    {
        public Car(int id, string name, string manufacturer, int price, int year)
        {
            ID = id;
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            Year = year;
        }
    }

    class Truck : Vehicle
    {

        public Truck(int id, string name, string manufacturer, int price, int year)
        {
            ID = id;
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            Year = year;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car(1, "Camry", "FERRARI", 90000, 2022));
            cars.Add(new Car(2, "Wigo", "TOYOTA", 150000, 1980));
            cars.Add(new Car(3, "Raize", "VINFAST", 200000, 2020));
            cars.Add(new Car(4, "Fadil", "FERRARI", 250000, 2021));
            cars.Add(new Car(5, "VF 5 Plus", "VINFAST", 450000, 2000));
            cars.Add(new Car(6, "VF e34", "VINFAST", 150000, 2010));

            Console.WriteLine("Cac xe co gia tu 100.000 den 250.000");
            var carsInRange = cars.Where(car => car.Price >= 100000 && car.Price <= 250000);
            foreach (var car in carsInRange)
            {
                Console.WriteLine($"Car Name: {car.Name}, Price: {car.Price}");
            }

            Console.WriteLine("\nCac xe co nam san xuat > 1990");
            var carsAfter1990 = cars.Where(car => car.Year > 1990);
            foreach (var car in carsAfter1990)
            {
                Console.WriteLine($"Car Name: {car.Name}, Year: {car.Year}");
            }

            Console.WriteLine("\nDanh sach cac xe duoc nhom theo hang");
            var carGroupByManufacturer = cars.GroupBy(car => car.Manufacturer)
                                             .Select(group => new
                                             {
                                                 Manufacturer = group.Key,
                                                 TotalPrice = group.Sum(car => car.Price)
                                             });
            foreach (var group in carGroupByManufacturer)
            {
                Console.WriteLine($"Manufacturer: {group.Manufacturer}, Total Price: {group.TotalPrice}");
            }

            Console.WriteLine("----------------------------");

            List<Truck> trucks = new List<Truck>();
            trucks.Add(new Truck(1, "Venue", "HYNDAI", 300000, 2019));
            trucks.Add(new Truck(2, "DMX UTZ", "ISUZU", 400000, 2024));
            trucks.Add(new Truck(3, "Canter 4.99", "FUSO", 500000, 2000));
            trucks.Add(new Truck(4, "QKR-F E4", "ISUZU", 500000, 2021));
            trucks.Add(new Truck(5, "Fa 140 L", "FUSO", 500000, 1986));

            Console.WriteLine("\nDanh sach xe Truck theo thu tu nam san xuat moi nhat");

            var trucksOrderedByYear = trucks.OrderByDescending(truck => truck.Year);
            foreach (var truck in trucksOrderedByYear)
            {
                Console.WriteLine($"Truck Name: {truck.Name}, Year: {truck.Year}");
            }

            Console.WriteLine("\nDanh sach xe Truck theo nha san xuat");

            foreach (var truck in trucks)
            {
                Console.WriteLine($"Truck Name: {truck.Name}, Manufacturer: {truck.Manufacturer}");
            }

            Console.ReadLine();
        }
    }
}
