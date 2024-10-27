using UnityEngine;
using UnityEngine.EventSystems;

namespace UI_Marchand
{
    public class DropArea : MonoBehaviour, IDropHandler
    {
        public InventoryManager inventoryManager;

        private void Start()
        {
            if (inventoryManager == null)
            {
                inventoryManager = FindObjectOfType<InventoryManager>();
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            GameObject droppedItem = eventData.pointerDrag;
            if (droppedItem != null)
            {
                DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();
                if (draggableItem != null && inventoryManager != null)
                {
                    // Check if the item is being moved to a new panel
                    bool isMovedToDifferentPanel = droppedItem.transform != transform;
                    InventoryItem item = inventoryManager.GetItemBySlot(droppedItem);

                    if (isMovedToDifferentPanel && item != null)
                    {
                        // Buying logic if moving from Merchant to Inventory
                        if (transform == inventoryManager.inventoryGrid && PlayerController.moneyCount > 0)
                        {
                            PlayerController.moneyCount--;
                            inventoryManager.UpdateMoneyUI();
                            droppedItem.transform.SetParent(inventoryManager.inventoryGrid, false);  // Move to Inventory
                            Debug.Log($"{item.itemName} purchased and moved to inventory.");
                        }
                        // Selling logic if moving from Inventory to Merchant
                        else if (transform == inventoryManager.merchantGrid)
                        {
                            PlayerController.moneyCount++;
                            inventoryManager.UpdateMoneyUI();
                            droppedItem.transform.SetParent(inventoryManager.merchantGrid, false);  // Move to Merchant
                            Debug.Log($"{item.itemName} sold and moved to merchant.");
                        }
                        else
                        {
                            // Not enough money to buy the item; return to original position
                            Debug.Log("Not enough money to buy this item!");
                            droppedItem.transform.SetParent(draggableItem.OriginalParent, false);
                        }
                    }
                    else
                    {
                        // Dropped in the same panel; reset to original position
                        droppedItem.transform.SetParent(draggableItem.OriginalParent, false);
                        Debug.Log("Item dropped in the same panel, no transaction occurred.");
                    }
                }
            }
        }
    }
}
