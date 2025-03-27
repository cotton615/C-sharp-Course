namespace CSharpTasks {
    internal class Program 
    {
        static int InterpolationSearch(int[] arr, int seek, int left, int right) {
            if (left == right || arr[left] == arr[right]) {
                throw new ArgumentException($"Element {seek} is not found");
            } 
            
            int pos = left + ((seek - arr[left]) * (right - left)) / (arr[right] - arr[left]);
            if (arr[pos] == seek) {
                return pos;
            } else {
                if (arr[pos] < seek) {
                    left = pos + 1;
                } else if (arr[pos] > seek) {
                    right = pos - 1;
                }
            }
            
            return InterpolationSearch(arr, seek, left, right);
        }

        static int JumpSearch(int[] arr, int seek) {
            int step = (int)Math.Sqrt(arr.Length);

            for (int i = 0; i < arr.Length; i += step) {

                if (arr[i] < seek) {
                    continue;    
                } else {
                    for (int j = i - step; j < i; j++) {
                        if (arr[j] == seek) {
                            return j;
                        }
                    }
                }
            }
            throw new ArgumentException("Element is not found");
        }

        private static void Main() {
            int[] arr = new int[10];

            for (int i = 0; i < arr.Length; i++) {
                arr[i] = Random.Shared.Next(0, 11);
            }

            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();

            int index;
            int seek = 5;
            try {
                index = JumpSearch(arr, seek);
            } catch (Exception ex) {
                Console.WriteLine($"{ex.Message}");
                return;
            }

            Console.WriteLine($"Jump search:\nElement is found: {index}\n");

            try {
                index = InterpolationSearch(arr, seek, 0, arr.Length - 1);
            } catch (Exception ex) {
                Console.WriteLine($"{ex.Message}");
                return;
            }
            Console.WriteLine($"Interpolation search:\nElement is found: {index}");
        }
    }
}