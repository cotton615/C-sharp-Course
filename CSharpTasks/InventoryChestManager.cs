namespace CSharpTasks {
    public class InventoryChestManager {
        public bool InventoryToChest(Inventory inventory, Item item, Chest chest) { 
            if (chest.HasSpace()) {
                inventory.Remove(item);
                chest.PutInChest(item);
                return true;
            }
            return false;
        }
        
        public bool ChestToInventory(Chest chest, Item item, Inventory inventory) {
            if (inventory.HasSpace()) {
                inventory.Add(item);
                chest.TakeFromChest(item);
                return true;
            } 
            return false;
        }
    }
}