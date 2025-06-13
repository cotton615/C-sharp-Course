using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace EgorLesson {
    internal class Program {

        static int Search(List<KeyValuePair<string, double>> arr, string productName) {
            int low = 0;
            int high = arr.Count - 1;

            while (low <= high) {
                int mid = (low + high) / 2;
                int compare = string.CompareOrdinal(arr[mid].Key, productName);

                if (compare == 0) {
                    return mid;
                } else if (compare < 0) {
                    low = mid + 1;
                } else if (compare > 0) {
                    high = mid - 1;
                }
            }

            throw new ArgumentException("Element not found.");
        }


        static void Main(string[] args) {
            Console.WriteLine("Тестируем List");

            var productList = new List<KeyValuePair<string, double>>();
            for (var i = 0; i < 1_000_000; i++) {
                productList.Add(new KeyValuePair<string, double>($"SKU-{i}", i * 1.5));
            }

            productList.Add(new KeyValuePair<string, double>("SKU-TARGET", 999.99));

            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            KeyValuePair<string, double> foundItem = new KeyValuePair<string, double>("NOT-FOUND", 0);

            string productName = "SKU-TARGET";
            int index = Search(productList, productName);
            foundItem = productList[index];
            

            stopwatch.Stop();

            Console.WriteLine($"Найден товар: {foundItem.Key} с ценой {foundItem.Value}");
            Console.WriteLine($"Время поиска: {stopwatch.Elapsed.TotalMilliseconds} мс\n");

            Console.WriteLine("Тестируем Dictionary");
            var productDictionary = new Dictionary<string, double>();
            for (int i = 0; i < 1_000_000; i++) {
                productDictionary.Add($"SKU-{i}", i * 1.5);
            }
            productDictionary.Add("SKU-TARGET", 999.99);

            stopwatch.Restart();

            double price = productDictionary["SKU-TARGET"];
            stopwatch.Stop();

            Console.WriteLine($"Найден товар: SKU-TARGET с ценой {price}");
            Console.WriteLine($"Время поиска: {stopwatch.Elapsed.TotalMilliseconds} мс\n");
        }
    }
}