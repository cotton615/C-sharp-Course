namespace CSharpTasks {
    public class InventoryChestManager {
        /// <summary>
        /// Shifts item from chest to inventory
        /// </summary>
        /// <param name="inventory">Inventory, from which to take</param>
        /// <param name="item">Item to take</param>
        /// <param name="chest">Chest, in which shifts</param>
        /// <returns>Returns True in case of successfull operation, otherwise - False</returns>
        public bool InventoryToChest(Inventory inventory, Item item, Chest chest) { 
            if (chest.HasSpace()) {
                inventory.Remove(item);
                chest.PutInChest(item);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Shifts item from chest to inventory
        /// </summary>
        /// <param name="chest">Chest, from which to take</param>
        /// <param name="item">Item to take</param>
        /// <param name="inventory">Inventory, in which shifts</param>
        /// <returns>Returns True in case of successfull operation, otherwise - False</returns>
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
