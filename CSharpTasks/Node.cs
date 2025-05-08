namespace CSharpTasks {
    public class Node {
        // Getters and Setters
        public int Value { get; set; }

        public Node? Next { get; set; } = null;
        public Node? Previous { get; set; } = null;


        // Constructors
        public Node(int value) {
            Value = value;
        }
    }
}
