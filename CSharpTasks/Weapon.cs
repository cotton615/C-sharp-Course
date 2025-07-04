using System.Text;

namespace CSharpTasks {
    public class Weapon : Item {
        public int damage = 30;

        public Weapon(string name, string description, List<string> actions) : base(name, description, actions) {
        
        }

        public override string Use(Player player) {
            StringBuilder builder = new StringBuilder();
            switch (Name) {
                case "Железный меч":
                    builder.AppendLine("Вы ударяете мечом, но вдруг попадаете по стене. Лезвие ломается и отлетает вам в руку. Вы получаете - 30 урона.");
                    player.HealthPoints -= damage;
                    break;
                case "Деревянный лук":
                    builder.AppendLine("Вы стреляете из лука, и стрела рикошетит от стены вам в руку. Вы получаете - 30 урона.");
                    player.HealthPoints -= damage;
                    break;
                case "Магический посох":
                    builder.AppendLine("Вы стреляете фаерболом, который взрывается и наносит вам 30 урона.");
                    player.HealthPoints -= damage;
                    break;
            }

            return builder.ToString();
        }
    }
}
