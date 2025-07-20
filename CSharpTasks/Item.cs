using System.Diagnostics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CSharpTasks {
    public class Item {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Item(string name, string description) {
            Name = name;
            Description = description;
        }

        // Override to display all information about item
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Название: {Name}");
            stringBuilder.AppendLine($"Описание: {Description}");
            
            return stringBuilder.ToString();
        }
    }
}
