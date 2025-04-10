using System.Security.Cryptography;

namespace CSharpTasks {

    internal class Program {
        static int Partition(int[] array, int start, int end) {
            int marker = start; 
            for (int i = start; i < end; i++) {
                if (array[i] < array[end]) 
                {
                    (array[marker], array[i]) = (array[i], array[marker]);
                    marker += 1;
                }
            }
            (array[marker], array[end]) = (array[end], array[marker]);
            return marker;
        }

        static void QuickSort(int[] array, int start, int end) {
            if (start >= end)
                return;

            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot - 1);
            QuickSort(array, pivot + 1, end);
        }

        static int[] MergeSort(int[] arr, int threshold) {
            if (arr.Length <= threshold) {
                QuickSort(arr, 0, arr.Length-1);
                return arr;
            }

            int mid = arr.Length / 2;

            int[] leftArray = new int[mid];
            int[] rightArray = new int[arr.Length-mid];

            Array.Copy(arr, 0, leftArray, 0, mid);
            Array.Copy(arr, mid, rightArray, 0, arr.Length-mid);

            return Merge(MergeSort(leftArray, threshold), MergeSort(rightArray, threshold));
        }

        static int[] Merge(int[] leftArr, int[] rightArr) {
            int leftPointer = 0;
            int rightPointer = 0;

            int[] merged = new int[leftArr.Length + rightArr.Length];

            for (int i = 0; i < merged.Length; i++) {

                if (leftPointer < leftArr.Length && rightPointer < rightArr.Length) {

                    if (leftArr[leftPointer] > rightArr[rightPointer]) {
                        merged[i] = rightArr[rightPointer];
                        rightPointer++;
                    } else {
                        merged[i] = leftArr[leftPointer];
                        leftPointer++;
                    }
                } else if (leftPointer < leftArr.Length){
                    merged[i] = leftArr[leftPointer];
                    leftPointer++;
                } else if (rightPointer < rightArr.Length) {
                    merged[i] = rightArr[rightPointer];
                    rightPointer++;
                }
            }

            return merged;
        }

        static void Main() {
            int[] arr = new int[100];
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = Random.Shared.Next(0, 21);
            }

            Console.WriteLine("Default array: ");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"{arr[i]} ");
            }

            int threshold = arr.Length / 2; // threshold, to which MergeSort divides array
            arr = MergeSort(arr, threshold);
            Console.WriteLine("\n\nMerge+Quick Sorted array: ");
            for (int i = 0; i < arr.Length; i++) {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}