using System.Reflection;

namespace CSharpTasks {
    public class Potion : Item {
        public Potion(string name, string description) : base(name, description, ["Выпить"]) {
            
        }

        public override string Use(Player player) {
            int toHeal = (player.MaxHealth * 20) / 100;
            int missingHp = player.MaxHealth - player.HealthPoints;
            int healAmount = Math.Min(toHeal, missingHp);

            player.HealthPoints += healAmount;

            return "Вы выпиваете зелье и чувствуете прилив сил.";
        }

    }
}
