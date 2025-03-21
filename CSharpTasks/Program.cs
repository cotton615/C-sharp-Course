namespace CSharpTasks
{
    internal class Program
    {
      /*Задание: Реализация метода TryGetValue для массива
        Реализуйте метод TryGetValue, который выполняет линейный поиск элемента в массиве целых чисел.

        Метод должен соответствовать следующим требованиям:
            • Принимает на вход массив целых чисел и искомое число.
            • Если элемент найден, метод возвращает true и инициализирует out-параметр индексом найденного элемента.
            • Если элемент не найден, метод возвращает false, а out-параметр получает значение -1.
            • Поиск должен выполняться линейно (без встроенных методов поиска).
            • Задокументировать метод summary комментарием.*/

        /// <summary>
        ///  Finds the element in the array.
        /// </summary>
        /// <param name="arr">Array, in which seeks.</param>
        /// <param name="seek">Element, which it seeks.</param>
        /// <param name="index">The index, which will be returned.</param>
        /// <returns>Index in case if element is found and returns -1 if element is not found.</returns>
        static bool TryGetValue(int[] arr, int seek, out int index) {
            for (int i = 0; i < arr.Length; i++) {

                if (arr[i] == seek) {
                    index = i;
                    Console.WriteLine($"Element {seek} is found.");
                    return true;
                } 
            }
            Console.WriteLine($"Element {seek} isn't found in the given array");
            index = -1;
            return false;
        }


      /*Задание: Реализация метода FindIndex для массива

        Реализуйте метод FindIndex, который выполняет линейный поиск элемента в массиве целых чисел.

        Метод должен соответствовать следующим требованиям:
            • Принимает на вход массив целых чисел и искомое число.
            • Если элемент найден, метод возвращает его индекс.
            • Если элемент не найден, метод выбрасывает исключение InvalidOperationException с сообщением "Элемент не найден в массиве".
            • Поиск должен выполняться линейно (без встроенных методов поиска).
            • Метод должен быть задокументирован с помощью summary-комментария.*/

        /// <summary>
        /// Finds index of the sought element.
        /// </summary>
        /// <param name="arr">Array, in which seek.s</param>
        /// <param name="seek">Element, index of which it must find.</param>
        /// <returns>Index of the sought element.</returns>
        /// <exception cref="InvalidOperationException">Throws exception, if element is not found.</exception>
        static int FindIndex(int[] arr, int seek) {
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == seek) {
                    return i;
                } 
            }
            throw new InvalidOperationException($"Element {seek} isn't found in the given array.");
        }

        static void Main()
        {
            int[] arr = new int[5];
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = Random.Shared.Next(0, 11);
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

            try {
                int result = FindIndex(arr, 5);
                Console.WriteLine($"Index of the sought element: {result}.");
            } catch (InvalidOperationException e) {
                Console.WriteLine(e.Message);
            }

            TryGetValue(arr, 5, out int index);
        }
    }
}