using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Marchand
{
    public class InventoryManager : MonoBehaviour
    {
        public GameObject inventorySlotPrefab;
        public Transform inventoryGrid; // Main Panel (Inventory)
        public Transform merchantGrid;  // Merchant Panel
        public TMP_Text moneyText;
        
        private List<GameObject> inventorySlots = new List<GameObject>();
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        private List<InventoryItem> selectedItems = new List<InventoryItem>();

        void Start()
        {
            AddItemToInventory("Potion", 1);
            AddItemToInventory("Épée", 1);
            AddItemToInventory("Bouclier", 1);
            UpdateMoneyUI();
        }

        public void AddItemToInventory(string itemName, int quantity)
        {
            InventoryItem newItem = new InventoryItem(itemName, quantity);
            inventoryItems.Add(newItem);

            GameObject slot = Instantiate(inventorySlotPrefab, merchantGrid); // Add to Merchant Panel
            inventorySlots.Add(slot);

            Button button = slot.GetComponentInChildren<Button>();
            button.GetComponentInChildren<TMP_Text>().text = newItem.itemName;
            slot.AddComponent<DraggableItem>();

            button.onClick.AddListener(() => HandleItemTransaction(slot));

            Toggle toggle = slot.GetComponentInChildren<Toggle>();
            toggle.onValueChanged.AddListener(isOn => ToggleItemSelection(newItem, isOn));
        }

        public void HandleItemTransaction(GameObject slot)
        {
            bool isInMerchant = slot.transform.parent == merchantGrid;
            InventoryItem item = GetItemBySlot(slot);

            if (item != null)
            {
                if (isInMerchant)
                {
                    if (selectedItems.Contains(item))
                    {
                        BuyItem(item);
                    }
                }
                else
                {
                    if (selectedItems.Contains(item))
                    {
                        SellItems();
                    }
                }
            }
        }

        private void BuyItem(InventoryItem item)
        {
            int totalCost = selectedItems.Count; 
            if (PlayerController.moneyCount >= totalCost)
            {
                PlayerController.moneyCount -= totalCost; 
                UpdateMoneyUI();

                foreach (var selectedItem in selectedItems)
                {
                    var slot = GetSlotByItem(selectedItem);
                    if (slot != null)
                    {
                        slot.transform.SetParent(inventoryGrid, false);
                        Debug.Log($"{selectedItem.itemName} purchased and moved to inventory.");
                    }
                }
                selectedItems.Clear();
                ResetToggles();
            }
            else
            {
                Debug.Log("Not enough money to buy selected items!");
            }
        }

        private void SellItems()
        {
            foreach (var item in selectedItems)
            {
                var slot = GetSlotByItem(item);
                if (slot != null)
                {
                    PlayerController.moneyCount++; 
                    UpdateMoneyUI();
                    slot.transform.SetParent(merchantGrid, false); 
                    Debug.Log($"{item.itemName} sold and moved to merchant.");
                }
            }
            selectedItems.Clear(); 
            ResetToggles(); 
        }

        public void UpdateMoneyUI()
        {
            if (moneyText != null)
            {
                moneyText.text = "Money: " + PlayerController.moneyCount;
            }
        }

        public void ToggleItemSelection(InventoryItem item, bool isSelected)
        {
            if (isSelected)
            {
                if (!selectedItems.Contains(item))
                {
                    selectedItems.Add(item);
                    Debug.Log("Selected item: " + item.itemName);
                }
            }
            else
            {
                selectedItems.Remove(item);
                Debug.Log("Deselected item: " + item.itemName);
            }
        }

        public InventoryItem GetItemBySlot(GameObject slot)
        {
            int index = inventorySlots.IndexOf(slot);
            if (index >= 0 && index < inventoryItems.Count)
            {
                return inventoryItems[index];
            }
            return null;
        }

        public GameObject GetSlotByItem(InventoryItem item)
        {
            int index = inventoryItems.IndexOf(item);
            if (index >= 0 && index < inventorySlots.Count)
            {
                return inventorySlots[index];
            }
            return null;
        }

        private void ResetToggles()
        {
            foreach (var slot in inventorySlots)
            {
                Toggle toggle = slot.GetComponentInChildren<Toggle>();
                if (toggle != null)
                {
                    toggle.isOn = false; 
                }
            }
            selectedItems.Clear();
        }
    }

    [System.Serializable]
    public class InventoryItem
    {
        public string itemName;
        public int quantity;

        public InventoryItem(string name, int qty)
        {
            itemName = name;
            quantity = qty;
        }
    }
}
