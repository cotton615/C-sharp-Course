using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CSharpTasks {

    internal class Program {
        /// <summary>
        /// Displays all of the possible options of the program.
        /// </summary>
        /// <returns>Returns an answer from the user.</returns>
        static string DisplayOptions() {
            Console.WriteLine("--- Интерактивный словарь ---");
            Console.WriteLine("Выберите действие:\n");
            Console.WriteLine("1. Добавить/обновить термин");
            Console.WriteLine("2. Найти определение термина");
            Console.WriteLine("3. Удалить термин");
            Console.WriteLine("4. Показать все термины и определения");
            Console.WriteLine("5. Показать количество терминов");
            Console.WriteLine("6. Выход");

            string enter = Console.ReadLine();
            return enter;
        }

        /// <summary>
        /// Updates term, in case if it already exists.
        /// </summary>
        /// <param name="Terms">Dictionary, that contains all terms.</param>
        /// <param name="termName">Term name, that needs to be written to the dictionary.</param>
        /// <param name="termDefinition">Definition of the term.</param>
        static void UpdateTerm(Dictionary<string, string> Terms, string termName, string termDefinition) {
            while (true) {
                string option = Console.ReadLine();
                if (option.ToLower() == "да") {
                    Terms[termName] = termDefinition;
                    break;
                } else if (option.ToLower() == "нет") {
                    break;
                } else {
                    continue;
                }
            }
        }

        /// <summary>
        /// Adds term into the dictionary.
        /// </summary>
        /// <param name="Terms">Dictionary, that contains all terms.</param>
        /// <param name="termName">Term name, that needs to be written to the dictionary.</param>
        /// <param name="termDefinition">Definition of the term.</param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if term already exists in the dictionary.</exception>
        static void AddTerm(Dictionary<string, string> Terms, string termName, string termDefinition) {
            if (Terms.ContainsKey(termName) && Terms[termName] == termDefinition) {
                return;
            } 

            if (Terms.ContainsKey(termName)) {
                throw new Exception("Такой термин уже существует. Перезаписать? (Да / Нет)");
            }

            Terms.Add(termName, termDefinition);
        }

        /// <summary>
        /// Finds term in the dictionary by it's name.
        /// </summary>
        /// <param name="Terms">Dictionary, that contains all terms.</param>
        /// <param name="termName">Term name, that needs to be found.</param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if term is not found.</exception>
        static void FindTerm(Dictionary<string, string> Terms, string termName) {
            if (!Terms.ContainsKey(termName)) {
                throw new Exception("Термин не найден");
            }

            Console.WriteLine($"Определение: [{Terms[termName]}]");
            Console.WriteLine("\n\n\n");
        }

        /// <summary>
        /// Deletes term by it's name.
        /// </summary>
        /// <param name="Terms">Dictionary, that contains all terms.</param>
        /// <param name="termName">Term name, that needs to be deleted.</param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if term is not found.</exception>
        static void DeleteTerm(Dictionary<string, string> Terms, string termName) {
            if (!Terms.ContainsKey(termName)) {
                throw new Exception("Термин не найден");
            }
            Terms.Remove(termName);
        }

        /// <summary>
        /// Displays all terms of the dictionary.
        /// </summary>
        /// <param name="Terms">Dictionary, that contains all terms.</param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if dictionary is empty.</exception>
        static void DisplayAllTerms(Dictionary<string, string> Terms) {
            if (Terms.Count == 0) {
                throw new Exception("Словарь пуст.");
            }

            string[] keys = new string[Terms.Count];
            int i = 0;

            foreach (var key in Terms.Keys) {
                keys[i] = key;
                i++;
            }

            for (int j = 0; j < keys.Length; j++) {
                Console.WriteLine($"{keys[j]}: [{Terms[keys[j]]}]");
            }
            Console.WriteLine("\n\n\n");
        }

        /// <summary>
        /// Counts all of the terms in the dictionary.
        /// </summary>
        /// <param name="Terms">Dictionary, that contains all terms.</param>
        /// <returns>Return count of all terms in the dictionary.</returns>
        static int CountAllTerms(Dictionary<string, string> Terms) {
            int count = 0;

            foreach (var key in Terms.Keys) {
                count++;
            }

            return count;
        }

       static void Main() {
            Dictionary<string, string> Terms = new Dictionary<string, string>();

            while (true) {
                string enter = DisplayOptions();

                if (int.TryParse(enter.Trim(), out int option) && option > 0 && option <= 6) {
                    switch (option) {
                        case 1:
                            {
                                Console.Clear();

                                Console.WriteLine("Введите название термина: ");
                                string termName = Console.ReadLine();
                                Console.WriteLine("Введите определение термина: ");
                                string termDefinition = Console.ReadLine();

                                if (termName.Trim() == "" || termDefinition.Trim() == "") {
                                    Console.WriteLine("Термин и его определение не могут быть пустыми.");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    continue;
                                }
                                try {
                                    AddTerm(Terms, termName.Trim(), termDefinition.Trim());
                                } catch (Exception ex) {
                                    Console.Clear();
                                    Console.WriteLine($"{ex.Message}");
                                    UpdateTerm(Terms, termName.Trim(), termDefinition.Trim());
                                }
                                Console.Clear();
                                continue;
                            }

                        case 2: 
                            {
                                Console.Clear();
                                Console.WriteLine("Введите термин, определение которого желаете найти: ");
                                string termName = Console.ReadLine();
                                try {
                                    FindTerm(Terms, termName.Trim());
                                } catch (Exception ex) {
                                    Console.Clear();
                                    Console.WriteLine($"{ex.Message}");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                            
                                continue;
                            }
                        case 3: 
                            {
                                Console.Clear();
                                Console.WriteLine("Введите термин, который желаете удалить из словаря: ");
                                string termName = Console.ReadLine();
                                try {
                                    DeleteTerm(Terms, termName.Trim());
                                } catch (Exception ex) {
                                    Console.Clear();
                                    Console.WriteLine($"{ex.Message}");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }

                                continue;
                            }
                        case 4:
                            Console.Clear();

                            try {
                                DisplayAllTerms(Terms);
                            } catch (Exception ex) {
                                Console.Clear();
                                Console.WriteLine($"{ex.Message}");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            continue;
                        case 5:
                            Console.Clear();
                            Console.WriteLine($"Количество записей - {CountAllTerms(Terms)}.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            continue;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Выход...");
                            return;
                    }
                    continue;
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