using System;
using System.Diagnostics;
using System.Security.Cryptography;
using CSharpTasks;

namespace EgorLesson {


    internal class Program {
        static void DisplayDictionary(Dictionary<Car, List<string>> carsAndOwners) {
            foreach (var car in carsAndOwners) {
                Console.WriteLine($"{car.Key}: {string.Join(", ", car.Value)}");
            }
        }

        static void Main() {
            Car car1 = new Car("Ford", "Mustang", ["Michael", "Jack"]);
            Car car2 = new Car("Toyota", "Supra", ["John"]);
            Dictionary<Car, List<string>> carsAndOwners = new Dictionary<Car, List<string>>();

            Console.WriteLine(car1.ToString());
            Console.WriteLine(car2.ToString());
            Console.WriteLine($"Car1 Equals car2: {car1.Equals(car2)}. car1 Hash Code: {car1.GetHashCode()}");
            Console.WriteLine($"Car2 Equals car1: {car2.Equals(car1)}. car2 Hash Code: {car2.GetHashCode()}");
                
            carsAndOwners.Add(car1, car1.PrevOwners);
            carsAndOwners.Add(car2, car2.PrevOwners);
            Console.WriteLine("\nAdded 2 cars to the dictionary.");

            DisplayDictionary(carsAndOwners);

            carsAndOwners.Remove(car1);

            Console.WriteLine("\nRemoved car1.");
            Console.WriteLine($"Contains car2: {carsAndOwners.ContainsKey(car2)}");

            DisplayDictionary(carsAndOwners);
        }
    }
}