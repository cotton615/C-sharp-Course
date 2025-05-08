namespace CSharpTasks {
    public class LinkedList {

        // Getters and Setters
        private Node? _head { get; set; }
        private Node? _tail { get; set; }

        public int Count { get; private set; }
        public Node? Head => _head;
        public Node? Last => _tail;


        // Constructors
        /// <summary>
        /// Creates a list of n-elements.
        /// </summary>
        /// <param name="count">Number of elements in the LinkedList.</param>
        /// <exception cref="ArgumentOutOfRangeException">If given count is lesser than 0, throws exception.</exception>
        public LinkedList(int count) {
            if (count < 0) {
                throw new ArgumentOutOfRangeException("Count must be a positive integer.");
            }

            Node? previousNode = null;
            for (int i = 1; i < count + 1; i++) { 
                Node newNode = new Node(i);

                if (previousNode != null) {
                    previousNode.Next = newNode;
                    newNode.Previous = previousNode;
                } else {
                    _head = newNode;
                }

                previousNode = newNode;
            }
            _tail = previousNode;
            Count = count;
        }
        

        // Methods
        /// <summary>
        /// Adds a Node with a given Value to the end of the Linked List.
        /// </summary>
        /// <param name="value">Value, given to the node.</param>
        public void Add(int value) {
            if (_head is null) {
                _head = new Node(value);
                _tail = _head;
                _head.Previous = null;
            } else {
                Node newNode = new Node(value);
                newNode.Previous = _tail;
                newNode.Next = null;
                _tail.Next = newNode;
                _tail = newNode;
            }
            Count++;
        }

        public void Remove(int index) {
            if (index < 0 || index >= Count) { 
                throw new ArgumentOutOfRangeException("Index is out of bounds of the Linked List.");
            }

            if (index == 0) {
                _head = _head.Next;
                if (_head is not null) { 
                    _head.Previous = null;
                }
            } else {
                Node? current = _head.Next;
                Node? previous = _head;

                for (int i=1; i < index; i++) {
                    previous = current;
                    current = current.Next;
                }
                previous.Next = current.Next;
                if (current.Next is not null) {
                    current.Next.Previous = previous;
                } else {
                    _tail = previous;
                }
            }
            Count--;
        }
    }
}
