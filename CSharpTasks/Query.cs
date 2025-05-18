namespace CSharpTasks {
    internal class Query {
        private int[] _items;
        private int _head = 0;
        private int _tail = 0;
        private int _count = 0;

        // Constructors
        public Query(int volume) {
            _items = new int[volume];
        }

        // Methods
        public void Push(int item) {
            if (_count >= _items.Length) {
                throw new ArgumentOutOfRangeException("Query is full.");
            }

            _items[_tail++] = item;
            _count++;
        }

        public int Peek(int index) {
            if (index < 0 || index >= _items.Length) {
                throw new ArgumentOutOfRangeException("Index is out of bounds of the Query.");
            }

            return _items[(_head + index) % _items.Length];
        }
        
        public int Pop() {
            if (_count == 0) {
                throw new ArgumentOutOfRangeException("Query is empty.");
            }

            int item = _items[_head++];
            _count--;
            return item;
        }
    }
}
