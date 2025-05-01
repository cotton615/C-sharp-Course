namespace CSharpTasks {
    public class Node {
        private int _value;
        private Node _next;

        public int value => _value;
        public Node next => _next;

        public Node(int value, Node next) {
            this._value = value;
            this._next = next;
        }
    }
}
