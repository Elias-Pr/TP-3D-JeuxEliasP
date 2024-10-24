using UnityEngine;
using UnityEngine.EventSystems;

namespace UI_Marchand
{
    public class DropArea : MonoBehaviour, IDropHandler
    {
        public InventoryManager inventoryManager; // Reference to the InventoryManager

        private void Start()
        {
            // Find and assign InventoryManager if it's not assigned manually
            if (inventoryManager == null)
            {
                inventoryManager = FindObjectOfType<InventoryManager>();
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject droppedItem = eventData.pointerDrag; // The item being dragged
            if (droppedItem != null)
            {
                DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();
                if (draggableItem != null && inventoryManager != null) // Check if inventoryManager is not null
                {
                    // Get the item information from the InventoryManager
                    InventoryItem item = inventoryManager.GetItemBySlot(droppedItem);

                    if (item != null && PlayerController.moneyCount >= item.quantity) // Check if player has enough money
                    {
                        // Deduct the cost and update the UI
                        PlayerController.moneyCount -= item.quantity;
                        inventoryManager.UpdateMoneyUI();

                        // Set the item's parent to this panel (inventory) and reset its position
                        droppedItem.transform.SetParent(transform, false);
                        Debug.Log("Item successfully purchased and dropped in the inventory");

                        // Optionally, update inventory states (e.g., mark item as bought)
                        inventoryManager.MarkItemAsBought(item);
                    }
                    else
                    {
                        Debug.Log("Not enough money to buy this item!");
                    }
                }
            }
        }
    }

}