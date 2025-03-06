namespace CSharpTasks
{
    internal class Program
    {
        /* Напишите программу, которая запрашивает у пользователя его имя и возраст, 
        а затем выводит приветственное сообщение, включая имя и возраст пользователя. */
        static void Task1()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your age: ");
            int age;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter only number!");
                    continue;
                }
            }

            Console.WriteLine($"Hello, {name}! You are {age} years old.");
        }

        /* Создайте программу, которая объявляет переменные различных типов данных 
        (int, double, char, string) и выводит их значения на экран. */
        static void Task2()
        {
            int first = 17;
            double second = 3.14;
            char third = 'C';
            string fourth = "c sharp";

            Console.WriteLine($"Integer: {first},\nDouble: {second},\nChar: {third},\nString: {fourth}\n");
        }

        /* Напишите программу, которая принимает строку от пользователя и пытается преобразовать её в целое число. 
        Если преобразование успешно, программа должна вывести удвоенное значение числа. 
        В противном случае, программа должна вывести сообщение об ошибке. */
        static void Task3()
        {
            Console.WriteLine("Enter number: ");
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine(input * 2);
            }
            else
            {
                {
                    Console.WriteLine("Error: input is not an integer.");
                }
            }
        }

        /* Напишите программу, которая принимает от пользователя число и проверяет, 
        является ли оно положительным, отрицательным или нулём. 
        Выведите соответствующее сообщение. */
        static void Task4()
        {
            Console.WriteLine("Enter number: ");
            int input;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: input is not a number. Enter again: ");
                    continue;
                }
            }
            if (input == 0)
            {
                Console.WriteLine("Number is equal to 0.");
            }
            else if (input > 0)
            {
                Console.WriteLine("Number is bigger than zero.");
            }
            else if (input < 0)
            {
                Console.WriteLine("Number is lesser than zero.");
            }
        }

        /*Напишите программу, которая принимает от пользователя номер месяца 
        и выводит название месяца (например, 1 - Январь, 2 - Февраль и т.д.) 
        с использованием конструкции switch. */
        static void Task5()
        {
            Console.WriteLine("Enter number of the month: ");
            int input;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: input is not a number. Enter again: ");
                    continue;
                }
            }

            switch (input)
            {
                case 1:
                    Console.WriteLine("It is January.");
                    break;
                case 2:
                    Console.WriteLine("It is February.");
                    break;
                case 3:
                    Console.WriteLine("It is March.");
                    break;
                case 4:
                    Console.WriteLine("It is April.");
                    break;
                case 5:
                    Console.WriteLine("It is May.");
                    break;
                case 6:
                    Console.WriteLine("It is June.");
                    break;
                case 7:
                    Console.WriteLine("It is July.");
                    break;
                case 8:
                    Console.WriteLine("It is August.");
                    break;
                case 9:
                    Console.WriteLine("It is September.");
                    break;
                case 10:
                    Console.WriteLine("It is October.");
                    break;
                case 11:
                    Console.WriteLine("It is November.");
                    break;
                case 12:
                    Console.WriteLine("It is December.");
                    break;
            }

        }

        // Создайте программу, которая выводит все чётные числа от 1 до 100, используя цикл for.
        static void Task6()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        // Считает сумму чисел от 1 до 50, используя цикл While
        static void Task7()
        {
            int sum = 0;
            int i = 0;
            while (i < 50)
            {
                i += 1;
                sum += i;
                Console.WriteLine(sum);
            }
        }

        // Инициализирует массив из 10 элементов и заполняет его числами от 1 до 10. 
        // Затем выводит все элементы на экран
        static void Task8()
        {
            int[] arr = new int[10];
            for (int i=0; i<10; i++)
            {
                arr[i] = i + 1;
            }
            for (int i=0; i<arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        // Напишите программу, которая генерирует случайное число от 1 до 100 и выводит его на экран.
        // Используйте класс Random для генерации случайного числа.
        static void Task9()
        {
            Console.WriteLine(Random.Shared.Next(1, 101));
        }

        // Создайте двумерный массив размером 3x3 и заполните его случайными числами от 1 до 10. 
        // Выведите содержимое массива на экран.
        static void Task10()
        {
            int[,] arr = new int[3, 3];
            for (int i=0; i<3; i++)         // создание массива
            {
                for (int j=0; j<3;  j++)
                {
                    arr[i,j] = Random.Shared.Next(1, 11);
                }
            }

            for (int i=0; i<3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    Console.Write($"{arr[i,j]} ");
                }
                Console.WriteLine();
            }

        }

        // Напишите функцию, которая принимает два целых числа и возвращает их сумму.
        // Продемонстрируйте использование этой функции в программе.
        static int user_input()
        {
            int input;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Enter only number!");
                    continue;
                }
            }
        }
        static void Task11() 
        {
            Console.WriteLine("Enter first number: ");
            int input_1 = user_input();
            Console.WriteLine("Enter second number: ");
            int input_2 = user_input();
            Console.WriteLine($"The sum: {input_1 + input_2}");
        }

        // Напишите программу, которая создает список (List<int>) и заполняет его 5 случайными числами.
        // Затем программа должна вывести все числа на экран и их сумму.
        static void Task12()
        {
            List<int> arr = new List<int>();
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                int number = Random.Shared.Next(0, 11);
                arr.Add(number);
                sum += number;
            }
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine($"\nSum = {sum}");
        }

        /* Каждый солнечный день улитка, сидящая на дереве, поднимается вверх на 5 см, а каждый пасмурный день опускается вниз на 3 см.
         * В начале наблюдения улитка находилась на расстоянии А см от земли на 5-метровом дереве. 
         * Имеется 30-элементный массив, содержащий сведения о том, был ли соответствующий день наблюдения пасмурным или солнечным. 
         * Написать программу, определяющую местоположение улитки к концу 30-го дня наблюдения. */
        static void Snail()
        {
            bool[] sunny = new bool[30];
            int distance;
            Console.WriteLine("Enter distance in the beggining of observation: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out distance))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter only number!");
                    continue;
                }
            }
            for (int i = 0; i < sunny.Length; i++)
            {
                sunny[i] = Random.Shared.Next(0, 2) == 1;
                Console.Write($"{sunny[i]} ");
            }
            for (int i = 0; i < sunny.Length; i++)
            {
                if (sunny[i])
                {
                    distance += 5;
                } else
                {
                    distance -= 3;
                }
            }
            Console.WriteLine($"\nIn 30 days snail climbed for {distance} cm.");
        }
        static void Main()
        {
            Snail();
        }
    }
}
