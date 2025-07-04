using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CSharpTasks {
    public class Chest {
        private List<Item> chestItems = new List<Item>();
        public bool isOpened = false;
        public int Capacity {
            get => chestItems.Count;
        }
        public int MaxCapacity { private get; set; }


        // Constructor
        public Chest() { 
            chestItems = new List<Item>();
        }


        // Methods
        public override string ToString() {
            if (chestItems.Count == 0) {
                return "Сундук пуст.";
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Сундук:");
            for (int i = 0; i < chestItems.Count; i++) {
                builder.AppendLine($"{i + 1}. {chestItems[i].Name}");
            }

            return builder.ToString();
        }

        // These two methods are made solely for the intro of the game
        public void PutInChest(Item item) {
            chestItems.Add(item);
        }
        
        public void TakeFromChest(Item item) {
            chestItems.Remove(item);
        }
        public bool HasSpace() {
            if (Capacity == MaxCapacity) {
                return false;
            }

            return true;
        }

        public Item this[int index] {
            get {
                if ((index >= 1) && (index <= chestItems.Count)) {
                    return chestItems[index - 1];
                }

                throw new ArgumentOutOfRangeException("Index out of range.");
            }
        }
        
    }
}
