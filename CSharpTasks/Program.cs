using System.Linq.Expressions;
using CSharpTasks;

namespace EgorLesson {
    internal class Program {
        static void Main() {
            Character knight = new Character("Knight");
            Character hunter = new Character("Hunter");
            Character mage = new Character("Mage");

            Enemy orc = new Enemy("Orc");
            Enemy goblin = new Enemy("Goblin");
            Enemy undead = new Enemy("Undead");

            if (knight.Attack(hunter)) {
                Console.WriteLine("Knight attacked the hunter.");
            } else {
                Console.WriteLine("ERROR.");
            }

            if (hunter.Attack(orc)) {
                Console.WriteLine("Hunter attacked the orc");
            } else {
                Console.WriteLine("ERROR.");
            }

            if (undead.Attack(mage)) {
                Console.WriteLine("Undead attacked the mage");
            } else {
                Console.WriteLine("ERROR.");
            }

            try {
                mage.Attack(mage);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }
    }
}