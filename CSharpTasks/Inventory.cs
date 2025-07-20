using System.Text;

namespace CSharpTasks {
    public class Inventory {
        private List<Item> _items = new List<Item>();
        public int Count => _items.Count;
        public int Volume = 4;

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Инвентарь:");

            if (_items.Count == 0) {
                builder.AppendLine("Пусто");
                return builder.ToString();
            }

            for (int i = 0; i < _items.Count; i++) {
                builder.AppendLine($"{i+1}. {_items[i].Name}");
            }

            return builder.ToString();
        }

        public Item this[int index] {
            get {
                if ((index >= 1) && (index <= _items.Count)) { 
                    return _items[index-1];
                }

                throw new ArgumentOutOfRangeException("Index out of range.");
            }
        }

        public void Remove(Item item) {
            if (item is not null) {
               _items.Remove(item);
            } else {
                throw new ArgumentNullException("Tried to remove NULL Item from the Inventory.");
            }
        }

        public void Add(Item item) {
            if (item is not null) {
                _items.Add(item);
            } else {
                throw new ArgumentNullException("Tried to add NULL Item to the Inventory.");
            }
        }

        public bool HasSpace() { 
            if (this.Count == this.Volume) {
                return false;
            }

            return true;
        }
    }   
}
