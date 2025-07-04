using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CSharpTasks {
    public class Item {
        public List<string> Actions { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Creates Inheritance Class
        /// </summary>
        /// <param name="name">Name of the item.</param>
        /// <param name="description">Description of the item.</param>
        /// <param name="actions">Actions, that could be performed by this item.</param>
        public Item(string name, string description, List<string> actions) {
            Name = name;
            Description = description;
            Actions = actions;
        }

        // Override to display all information about item
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Название: {Name}");
            stringBuilder.AppendLine($"Описание: {Description}");
            stringBuilder.AppendLine("Доступные действия:");
            if (Actions.Count == 0) {
                stringBuilder.AppendLine("Пусто");
                return stringBuilder.ToString();
            } else {
                for (int i = 0; i < Actions.Count; i++) {
                    stringBuilder.AppendLine($"{i + 1}. {Actions[i]}");
                }
            }
            return stringBuilder.ToString();

        }

        public string PerformAction(int actionIndex, Player player) { 
            switch (actionIndex) {
                case 1:
                    return Use(player);
                default:
                    return "Данное действие не поддерживается для этого предмета.";
            }
        }

        public virtual string Use() {
            return $"Вы используете {Name}, но ничего не происходит...";
        }

        public virtual string? Use(Player player) {
            return null;
        }
    }
}
