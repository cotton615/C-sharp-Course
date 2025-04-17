
namespace CSharpTasks {

    internal class Program {
        
        static void RadixSort(int[] arr) {
            if (arr.Length <= 1) {
                return;
            }

            int maxValue = FindMaxValue(arr);

            for (int digitPlace = 1; digitPlace <= maxValue; digitPlace *= 10) {

                int[,] buckets = new int[10, arr.Length]; // Create a 2D array to hold the buckets for each digit (0-9)
                int[] bucketCount = new int[10]; // Array to count the number of elements in each bucket

                for (int i = 0; i < arr.Length; i++) {  // placing elements in their buckets
                    int digit = DigitFromNumber(arr[i], digitPlace);
                    int bucketIndex = bucketCount[digit];

                    buckets[digit, bucketIndex] = arr[i];
                    bucketCount[digit]++;
                }

                int index = 0;
                for (int i = 0; i < 10; i++) { // rearranging the array using the buckets
                    for (int j = 0; j < bucketCount[i]; j++) {
                        arr[index] = buckets[i, j];
                        index++;
                    }
                }
                
            }
        }

        /// <summary>
        /// Finds maximum value in the given array.
        /// </summary>
        /// <param name="arr">Array, in which seeks.</param>
        /// <returns>Return maximum value from the array.</returns>
        static int FindMaxValue(int[] arr) {
            int maxDigit = 0;
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] > maxDigit) {
                    maxDigit = arr[i];
                }
            }
            return maxDigit;
        }
        /// <summary>
        /// Extracts a digit from a number based on the specified place value.
        /// </summary>
        /// <param name="number">The number from which the digit is extracted.</param>
        /// <param name="digitToFind">The place value (1 for ones, 10 for tens, 100 for hundreds, etc.).</param>
        /// <returns>Returns the digit at the specified place value in the number.</returns>
        static int DigitFromNumber(int number, int digitToFind) {
            int digit = (number / digitToFind) % 10;

            return digit;
        }

        static void Main() {
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = Random.Shared.Next(0, 100);
            }

            Console.WriteLine("Default array: ");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"{arr[i]} ");
            }
            RadixSort(arr);

            Console.WriteLine("\n\nRadix Sorted array: ");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}