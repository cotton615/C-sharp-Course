namespace CSharpTasks {
    public class LinkedList {
        private Node _head;

        // Getters and setters
        public int value => _head.value;
        public Node head => _head;
        
        // Constructors
        /// <summary>
        /// Creates 1 node with given value and a reference to the next node.
        /// </summary>
        /// <param name="value">Value, which element contains.</param>
        /// <param name="next">Reference to the next node.</param>
        public LinkedList(int value, Node next) {
            _head = new Node(value, next);
        }
        /// <summary>
        /// Creates a list of n-elements.
        /// </summary>
        /// <param name="count">Number of elements in the LinkedList.</param>
        /// <exception cref="ArgumentOutOfRangeException">If given count is lesser than 0, throws exception.</exception>
        public LinkedList(int count) {
            if (count < 0) {
                throw new ArgumentOutOfRangeException("Count must be a positive integer.");
            }

            Node lastElement = null;
            for (int i = count; i > 0; i--) { 
                Node newElement = new Node(i, lastElement);
                lastElement = newElement;
            }
            _head = lastElement;
        }
    }
}
