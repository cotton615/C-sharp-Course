namespace CSharpTasks {

    internal class Program {

        static void ShellSort(int[] arr) {
            int d = arr.Length / 2;
            while (d > 0) { 
                for (int i = d; i < arr.Length; i++) {

                    int j = i;
                    int temp = arr[i];
                    while (j >= d && arr[j-d] > temp) {
                        arr[j] = arr[j - d];
                        j--;
                    }
                    arr[j] = temp;

                }
            d /= 2;
            }
        }

        static void CocktailSort(int[] arr, int start, int end) {
            while (start < end) {
                for (int i = start; i < end; i++) {

                    if (arr[i] > arr[i + 1]) {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }

                    for (int j = end; j > start; j--) {
                        if (arr[j] < arr[j - 1]) {
                            int temp = arr[j];
                            arr[j] = arr[j - 1];
                            arr[j - 1] = temp;
                        }
                    }
                }
                start += 1;
                end -= 1;
            }
        }

        static void InsertionSort(int[] arr) {
            for (int i = 1; i < arr.Length; i++) {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key) {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j+1] = key;
            }
        }
        
        static void SelectionSort(int[] arr, int start) {
            if (start == arr.Length) {
                return;
            }

            int minIndex = start;
            for (int i = start; i < arr.Length-1; i++) {
                if (arr[minIndex] > arr[i+1]) {
                    minIndex = i+1;
                } else if (arr[minIndex] < arr[i+1]){
                    continue;
                }
            }

            int temp = arr[minIndex];
            arr[minIndex] = arr[start]; 
            arr[start] = temp;
            SelectionSort(arr, start+1);
        }

        private static void Main() {
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = Random.Shared.Next(11);
            }

            Console.WriteLine("Default array: ");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("\n\n");

            SelectionSort(arr, 0);
            Console.WriteLine("Selection sorted array: ");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("\n\n");

            InsertionSort(arr);
            Console.WriteLine("Insertion sorted array: ");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("\n\n");

            ShellSort(arr);
            Console.WriteLine("Shell Sorted Array: ");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine("\n\n");

            CocktailSort(arr, 0, arr.Length - 1);
            Console.WriteLine("Cocktail Sorted Array: ");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"{arr[i]} ");
            }

        }
    }
}