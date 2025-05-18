namespace CSharpTasks {

    internal class Program {

       static void Main() {
            Query query = new Query(2);
            query.Push(7); 
            query.Push(2);

            Console.WriteLine($"Peek before pop: {query.Peek(0)} "); 
            int popped_item = query.Pop();
            Console.WriteLine($"Popped item: {popped_item}");
            Console.WriteLine($"Peek after pop: {query.Peek(0)} "); 
        }
    }
}