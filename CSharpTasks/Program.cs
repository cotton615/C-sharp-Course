using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CSharpTasks {
    internal class Program {

        static void DisplayMenu() {
            Console.WriteLine("--- Интерактивный словарь ---");
            Console.WriteLine("Выберите действие:\n");
            Console.WriteLine("1. Добавить/обновить термин");
            Console.WriteLine("2. Найти определение термина");
            Console.WriteLine("3. Удалить термин");
            Console.WriteLine("4. Показать все термины и определения");
            Console.WriteLine("5. Показать количество терминов");
            Console.WriteLine("6. Выход");
        }

        static void Main() {
            TermDict termDict = new TermDict();

            while (true) {
                DisplayMenu();
                string enter = Console.ReadLine().Trim();

                if (int.TryParse(enter, out int option) && option > 0 && option <= 6) {
                    switch (option) {
                        case 1: 
                            { 
                                Console.Clear();
                                Console.WriteLine("Введите название термина, который хотите добавить: ");
                                string termName = Console.ReadLine().Trim();

                                Console.WriteLine("Введите определение для этого термина:");
                                string termDefinition = Console.ReadLine().Trim();

                                Console.Clear();

                                if ((termName == "") || (termDefinition == "")) {
                                    Console.Clear();
                                    Console.WriteLine("Имя или определение термина не могут быть пустыми.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                } else {
                                    try {
                                        termDict.Add(termName, termDefinition);
                                        Console.WriteLine("Термин успешно добавлен.");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                    } 
                                    catch (ArgumentException ex) {
                                        Console.WriteLine(ex.Message);
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                    } 
                                    catch (InvalidOperationException ex) {
                                        Console.WriteLine(ex.Message);
                                        Console.WriteLine("Перезаписать? да / нет");

                                        string rewriteOption = Console.ReadLine().Trim().ToLower();
                                        if (rewriteOption == "да") {
                                            termDict.Update(termName, termDefinition);
                                            Console.WriteLine("Определение обновлено.");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                        } else {
                                            Console.Clear();
                                        }
                                    }
                                }
                                continue;
                            }
                        case 2: 
                            { 
                                Console.Clear();
                                Console.WriteLine("Введите имя термина, который желаете найти: ");
                                string termName = Console.ReadLine().Trim();
                                try {
                                    Console.WriteLine($"[{termDict.Find(termName)}]");
                                } 
                                catch (KeyNotFoundException ex) {
                                    Console.Clear();
                                    Console.WriteLine(ex.Message);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                                continue;
                            }
                        case 3: 
                            {
                                Console.Clear();
                                Console.WriteLine("Введите имя термина, который желаете удалить: ");
                                string termName = Console.ReadLine().Trim();

                                if (termDict.Remove(termName)) {
                                    Console.WriteLine("Термин успешно удалён.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                                Console.Clear();
                                continue;
                            }
                        case 4:
                            Console.Clear();
                            List<KeyValuePair<string, string>> terms = termDict.GetAllTerms();

                            for (int i = 0; i < terms.Count; i++) {
                                Console.WriteLine($"{terms[i].Key}: [{terms[i].Value}]");
                            }

                            continue;
                        case 5:
                            Console.Clear();
                            Console.WriteLine($"Всего терминов: {termDict.Count()}");
                            continue;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Выход...");
                            return;
                    }
                } else {
                    Console.Clear();
                    Console.WriteLine("Пожалуйста, выберите действие из списка.");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
    }
}