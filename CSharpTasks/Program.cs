namespace CSharpTasks {

    internal class Program {
        
       static void Main() {
            MyList myList1 = new MyList(3);

            for (int i = 0; i < myList1.Length; i++) {
                myList1[i] = Random.Shared.Next(0, 10);
            }
            Console.WriteLine("First MyList:");
            for (int i = 0; i < myList1.Length; i++) {
                Console.Write($"{myList1[i]} ");
            }

            MyList myList2 = new MyList(7);

            for (int i = 0; i < myList2.Length; i++) {
                myList2[i] = Random.Shared.Next(0, 10);
            }
            Console.WriteLine("\nSecond MyList:");
            for (int i = 0; i < myList2.Length; i++) {
                Console.Write($"{myList2[i]} ");
            }

            Console.WriteLine("\n\nAdded MyLists: ");
            MyList result = myList1 + myList2;
            for (int i = 0; i < result.Length; i++) {
                Console.Write($"{result[i]} ");
            }
            Console.WriteLine($"\n\nTest of ==: {myList1 == myList2} and !=: {myList1 != myList2}");
        }
    }
}