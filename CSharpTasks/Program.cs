namespace CSharpTasks {

    internal class Program {


        static void DisplayLinkedList(LinkedList linkedList) {
            Node? current = linkedList.Head;
            while (current != null) {
                Console.Write($"{current.Value} ");
                current = current.Next;
            }
        }

       static void Main() {
            LinkedList linkedList = new LinkedList(3);

            Node? current = linkedList.Head;
            Console.WriteLine("Created linked list:");
            DisplayLinkedList(linkedList);

            linkedList.Add(42);

            Console.WriteLine("\nAdded 42:");
            DisplayLinkedList(linkedList);

            linkedList.Remove(1);
            Console.WriteLine("\nRemoved 2:");
            DisplayLinkedList(linkedList);
        }
    }
}