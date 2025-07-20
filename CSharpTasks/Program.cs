using System;
using System.Diagnostics;
using System.Reflection;
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
        static void MainMenuInteraction(Player player, Chest chest, InventoryChestManager manager) {
            while (true) {
                Console.WriteLine(player.Inventory.ToString());
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
                        InventoryInteraction(manager, player, chest);
                        break;
                    case 2:
                        ChestInteraction(manager, player, chest);
                        break;
                    case 3:
                        return;
                }
            }
        }
        static void InventoryInteraction(InventoryChestManager manager, Player player, Chest chest) {
            while (true) {
                Console.Clear();
                Console.WriteLine(player.Inventory.ToString());
                Console.WriteLine($"{player.Inventory.Count + 1}. Выход из инвентаря");
                Console.WriteLine("\nЧто переложить в сундук?");

                int userInput = GetUserInputInt(player.Inventory.Count + 1);

                if (userInput == player.Inventory.Count + 1) { // Exit from the Inventory
                    Console.Clear();
                    break;
                } else {
                    Console.WriteLine($"Предмет: {player.Inventory[userInput].Name} успешно переложен в инвентарь.");
                    manager.InventoryToChest(player.Inventory, player.Inventory[userInput], chest);
                } 

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void ChestInteraction(InventoryChestManager manager, Player player, Chest chest) {
            while (true) {
                Console.Clear();
                Console.WriteLine(chest.ToString());
                Console.WriteLine($"{chest.Capacity + 1}. Выйти из сундука");
                Console.WriteLine("\nЧто хотите взять?");

                int userInput = GetUserInputInt(chest.Capacity + 1);
                if (userInput == chest.Capacity + 1) { // Exit from the Chest
                    Console.Clear();
                    break;
                }

                if (!manager.ChestToInventory(chest, chest[userInput], player.Inventory)) {
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
                Console.WriteLine($"Выберите размер сундука. Минимальное значение - {chest.MinCapacity}:");
                int chestCapacity = GetUserInputInt(int.MaxValue);
                if (chest.SetMaxCapacity(chestCapacity)) {
                    Console.Clear();
                    break;
                } else {
                    Console.Clear();
                }
            }

            Console.Clear();

            InventoryChestManager manager = new InventoryChestManager();

            Item key = new Item("Ржавый ключ", "Этот ключ открывает сундук.");
            Item healingPotion = new Item("Зелье лечения", "Восстанавливает 20% от максимального здоровья игрока");
            Item grandScroll = new Item("Древний свиток", "*Тут должно быть что-то про лор игры*");
            Item bone = new Item("Кость", "Кость какого-то существа");
            Item garbage = new Item("Мусор", "Бесполезный кусок мусора");

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
            Item? weapon = null;
            switch (userInput) {
                case 1:
                    weapon = new Item("Железный меч", "Обычный железный меч");
                    break;
                case 2:
                    weapon = new Item("Деревянный лук", "Обычный деревянный лук");
                    break;
                case 3:
                    weapon = new Item("Магический посох", "Деревянный посох Мага");
                    break;
            }

            if (weapon != null) {
                chest.PutInChest(weapon);
            }

            Console.Clear();
            Console.WriteLine($"Теперь вы играете за - {(PlayerType)userInput-1}");
            Thread.Sleep(2000);
            Console.Clear();

            MainMenuInteraction(player, chest, manager);
        }
    }
}