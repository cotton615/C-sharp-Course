
namespace CSharpTasks {
    public class Key : Item {
        private Chest linkedChest;
        public Key(string name, string description, List<string> actions, Chest chest) : base(name, description, actions) {
            linkedChest = chest;
        }

        public override string Use() {
            if (linkedChest.isOpened) {
                return "Сундук уже открыт.";
            }

            linkedChest.isOpened = true;
            return "Вы открываете сундук...";
        }

        public override string? Use(Player player) {
            return Use();
        }
    }
}
