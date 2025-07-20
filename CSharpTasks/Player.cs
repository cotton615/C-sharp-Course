namespace CSharpTasks {
    public class Player {
        public int HealthPoints { get;  private set; }
        public int Stamina { get; private set; }
        public int Strength { get; private set; } 
        public int Dexterity { get; private set; }
        public int Intelligence { get; private set; }
        public Inventory Inventory { get; private set; }
        public int MaxHealth = 100;

        public Player(PlayerType playerType) {
            HealthPoints = 100;
            Stamina = 100;
            Strength = 6;
            Dexterity = 6;
            Intelligence = 6;
            Inventory = new Inventory();
        }
    }
}