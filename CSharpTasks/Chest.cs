using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CSharpTasks {
    public class Chest {
        private List<Item> chestItems = new List<Item>();
        public int Capacity {
            get => chestItems.Count;
        }
        public int MinCapacity { get; private set; } = 6;
        public int MaxCapacity { get; private set; }


        // Constructor
        public Chest() { 
            chestItems = new List<Item>();
        }

        // Methods
        public bool SetMaxCapacity(int MaxChestCapacity) {
            int minChestCapacity = 6;
            if (MaxCapacity >= minChestCapacity) {
                this.MaxCapacity = MaxChestCapacity;
                return true;
            }
            return false;
        }

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
