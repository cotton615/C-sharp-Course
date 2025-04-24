namespace CSharpTasks {
    public class MyList {
        private int[] _items;


        // Getters and Setters
        public int Length => _items.Length;
        public int[] Items => _items;

        public int this[int index] {
            get => _items[index];
            set => _items[index] = value;
        }

        // Constructors
        public MyList(int length) {
            _items = new int[length];
        }

        public MyList() {
            _items = [];
        }

        public static MyList operator +(MyList firstArray, MyList secondArray) {
            MyList resultArray = new MyList(firstArray.Length + secondArray.Length);

            Array.Copy(firstArray.Items, resultArray._items, firstArray.Length);
            Array.Copy(secondArray.Items, 0, resultArray._items, firstArray.Length, secondArray.Length);

            return resultArray;
        }


        public static bool operator !=(MyList firstArray, MyList secondArray) {
            return !(firstArray == secondArray);
        }

        public static bool operator ==(MyList firstArray, MyList secondArray) {
            if (ReferenceEquals(firstArray, secondArray)) {
                return true;
            }

            if (firstArray is null || secondArray is null) {
                return false;
            }


            if (firstArray.Length != secondArray.Length) {
                return false;
            } else {
                for (int i = 0; i < firstArray.Length; i++) {
                    if (firstArray[i] != secondArray[i]) {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
