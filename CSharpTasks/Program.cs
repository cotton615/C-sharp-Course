using System;
using System.Diagnostics;
using CSharpTasks;

public enum PlayerType {
    Knight,
    Hunter,
    Mage
}

namespace EgorLesson {
    internal class Program {
        static int GetUserInputInt(int maxRange) {
            while (true) {
                if (int.TryParse(Console.ReadLine(), out int userInput)) { 
                    if ((userInput > 0) && (userInput <= maxRange)) {
                        return userInput;
                    } 
                }
                Console.WriteLine("Некорректный ввод.");
            }
        }
        /// <summary>
        /// Draws colorful bars of health and stamina
        /// </summary>
        /// <param name="points">Current Health or Stamina points</param>
        /// <param name="color">Color to use</param>
        static void DrawBar(int points, ConsoleColor color) {
            int totalBlocks = 20;
            int filled = points * totalBlocks / 100;
            int empty = totalBlocks - filled;

            var oldConsoleColor = Console.ForegroundColor;
            switch (color) {
                case ConsoleColor.Red:
                    Console.Write("Здоровье:     ");
                    break;
                case ConsoleColor.Green:
                    Console.Write("Выносливость: ");
                    break;
            }

            Console.Write("[");
            Console.ForegroundColor = color;
            Console.Write(new string('█', filled));
            Console.ForegroundColor = oldConsoleColor;
            Console.WriteLine(new string('░', empty) + $"] {points}%");
        }

        static void MainMenuInteraction(Player player, Inventory inventory, Chest chest, InventoryChestManager manager) {
            while (true) {
                DrawBar(player.HealthPoints, ConsoleColor.Red);
                DrawBar(player.Stamina, ConsoleColor.Green);

                Console.WriteLine(inventory.ToString());
                Console.WriteLine("-------------------------------");
                Console.WriteLine(chest.ToString());
                Console.WriteLine("-------------------------------");

                Console.WriteLine("Выберите, с чем взаимодействовать:");
                Console.WriteLine("1. Инвентарь");
                Console.WriteLine("2. Сундук");
                Console.WriteLine("3. Выйти из игры");

                int userInput = GetUserInputInt(3);
                switch (userInput) {
                    case 1:
                        InventoryInteraction(inventory, manager, player, chest);
                        break;
                    case 2:
                        ChestInteraction(chest, manager, inventory);
                        break;
                    case 3:
                        return;
                }
            }
        }

        static void InventoryInteraction(Inventory inventory, InventoryChestManager manager, Player player, Chest chest) {
            while (true) {
                if (player.isDead) {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ВЫ ПОГИБЛИ");
                    Environment.Exit(0);
                }
                Console.Clear();
                Console.WriteLine(inventory.ToString());
                Console.WriteLine($"{inventory.Count + 1}. Выход из инвентаря");
                Console.WriteLine("\nЧто хотите использовать?");

                int userInput = GetUserInputInt(inventory.Count + 1);
                if (userInput == inventory.Count + 1) {
                    Console.Clear();
                    break;
                }
                Item itemToInteract = inventory[userInput];
                
                Console.Clear();
                Console.WriteLine(itemToInteract.ToString());
                Console.WriteLine($"{itemToInteract.Actions.Count + 1}. Положить в сундук");
                Console.WriteLine($"{itemToInteract.Actions.Count + 2}. Выйти из меню предмета");

                userInput = GetUserInputInt(itemToInteract.Actions.Count + 2);
                if (userInput == itemToInteract.Actions.Count + 1) {
                    if (!manager.InventoryToChest(inventory, itemToInteract, chest)) {
                        Console.WriteLine("Сундук полон!");
                        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                        Console.ReadLine();
                    }
                    Console.Clear();
                    break;
                } else if (userInput == itemToInteract.Actions.Count + 2) {
                    Console.Clear();
                    break;
                }

                Console.WriteLine(itemToInteract.PerformAction(userInput, player));
                if (itemToInteract is Potion) {
                    inventory.Remove(itemToInteract);
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void ChestInteraction(Chest chest, InventoryChestManager manager, Inventory inventory) {
            while (true) {
                Console.Clear();
                Console.WriteLine(chest.ToString());
                Console.WriteLine($"{chest.Capacity + 1}. Выйти из сундука");
                Console.WriteLine("\nЧто хотите взять?");

                int userInput = GetUserInputInt(chest.Capacity + 1);

                if (userInput == chest.Capacity + 1) {
                    Console.Clear();
                    break;
                }

                if (!manager.ChestToInventory(chest, chest[userInput], inventory)) {
                    Console.WriteLine("Ваш инвентарь полон! ");
                    Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                    Console.ReadLine();
                }
                Console.Clear();
            }
        }

        static void Main() {
            Chest chest = new Chest();
            while (true) {
                Console.WriteLine("Выбрите размер сундука. Минимальное значение - 6:");
                int chestCapacity = GetUserInputInt(int.MaxValue);
                if (chestCapacity >= 6) {
                    chest.MaxCapacity = chestCapacity;
                    break;
                } else if (chestCapacity < 6) { 
                    Console.Clear();
                }
            }
            Console.Clear();

            Inventory inventory = new Inventory();
            InventoryChestManager manager = new InventoryChestManager();

            Key key = new Key("Ржавый ключ", "Этот ключ открывает сундук.", ["Использовать"], chest);
            Potion healingPotion = new Potion("Зелье лечения", "Восстанавливает 20% от максимального здоровья игрока");
            Item grandScroll = new Item("Древний свиток", "*Тут должно быть что-то про лор игры*", []);
            Item bone = new Item("Кость", "Кость какого-то существа", []);
            Item garbage = new Item("Мусор", "Бесполезный кусок мусора", []);

            chest.PutInChest(key);
            chest.PutInChest(healingPotion);
            chest.PutInChest(grandScroll);
            chest.PutInChest(bone);
            chest.PutInChest(garbage);

            Console.WriteLine("Выберите ваш класс:");
            Console.WriteLine("1. Рыцарь");
            Console.WriteLine("2. Охотник");
            Console.WriteLine("3. Маг");
             
            int userInput = GetUserInputInt(3);
            Player player = new Player((PlayerType)userInput-1);
            Weapon weapon = null;
            switch (userInput) {
                case 1:
                    weapon = new Weapon("Железный меч", "Обычный железный меч", ["Ударить"]);
                    break;
                case 2:
                    weapon = new Weapon("Деревянный лук", "Обычный деревянный лук", ["Выстрелить"]);
                    break;
                case 3:
                    weapon = new Weapon("Магический посох", "Деревянный посох Мага", ["Выстрелить"]);
                    break;
            }

            if (weapon != null) {
                chest.PutInChest(weapon);
            }

            Console.Clear();
            Console.WriteLine($"Теперь вы играете за - {player.CharacterClass}");
            Console.WriteLine("В кармане вы обнаруживаете ключ...");
            Thread.Sleep(2000);

            while (true) {
                Console.Clear();
                Console.WriteLine(key.ToString());

                int actionIndex = GetUserInputInt(key.Actions.Count);
                Console.Clear();
                Console.WriteLine(key.PerformAction(actionIndex, player));

                if (actionIndex == 1) {
                    break;
                }
            }

            MainMenuInteraction(player, inventory, chest, manager);
        }
    }
}