namespace CSharpTasks {
    public class Player {
        public int HealthPoints { get;  set; }
        public int Stamina { get; private set; }
        public int Strength { get; private set; } 
        public int Dexterity { get; private set; }
        public int Intelligence { get; private set; }
        public string CharacterClass { get; private set; }

        public int MaxHealth = 100;
        public bool isDead => HealthPoints <= 0;

        public static string GetPlayerTypeName(PlayerType type) {
            return type switch {
                PlayerType.Knight => "Рыцарь",
                PlayerType.Hunter => "Охотник",
                PlayerType.Mage => "Маг",
            };
        }

        public Player(PlayerType playerType) {
            HealthPoints = 100;
            Stamina = 100;
            Strength = 6;
            Dexterity = 6;
            Intelligence = 6;
            CharacterClass = GetPlayerTypeName(playerType);
        }
    }
}