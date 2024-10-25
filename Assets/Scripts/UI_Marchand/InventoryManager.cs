using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Marchand
{
    public class InventoryManager : MonoBehaviour
    {
        public GameObject inventorySlotPrefab;  // Prefab pour les slots d'inventaire
        public Transform inventoryGrid;         // Le parent contenant la grille d'inventaire (Main Panel)
        public Transform merchantGrid;          // Le parent secondaire (Other panel where items are initially)
        public TMP_Text moneyText;              // Text UI for showing player's money
        
        private List<GameObject> inventorySlots = new List<GameObject>(); // Liste des slots d'inventaire
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        private List<InventoryItem> selectedItems = new List<InventoryItem>();

        void Start()
        {
            AddItemToInventory("Potion", 1);
            AddItemToInventory("Épée", 1);
            AddItemToInventory("Bouclier", 1);
            UpdateMoneyUI();
        }

        // Method to add an item to the inventory
        public void AddItemToInventory(string itemName, int quantity)
        {
            InventoryItem newItem = new InventoryItem(itemName, quantity);
            inventoryItems.Add(newItem);
    
            GameObject slot = Instantiate(inventorySlotPrefab, merchantGrid); // Add to the other panel (merchant)
            inventorySlots.Add(slot); // Add the slot to the list of slots
    
            Button button = slot.GetComponentInChildren<Button>();
            button.GetComponentInChildren<TMP_Text>().text = newItem.itemName;

            // Add the drag-and-drop handler to the slot
            slot.AddComponent<DraggableItem>();

            // Add a listener to the button for item selection
            button.onClick.AddListener(() => MoveSelectedItemsToMainInventory());

            Toggle toggle = slot.GetComponentInChildren<Toggle>();
            toggle.onValueChanged.AddListener(isOn => ToggleItemSelection(newItem, isOn));
        }

        // Method to move selected items from the secondary panel to the main inventory
        public void MoveSelectedItemsToMainInventory()
        {
            int totalCost = CalculateTotalSelectedItemsCost();

            if (PlayerController.moneyCount >= totalCost)
            {
                PlayerController.moneyCount -= totalCost;
                UpdateMoneyUI();
                
                // Pour chaque slot dans l'inventaire
                foreach (GameObject slot in inventorySlots)
                {
                    Toggle toggle = slot.GetComponentInChildren<Toggle>();
                    if (toggle != null && toggle.isOn)
                    {
                        // Vérifie si le slot est dans le merchant panel et le déplace vers le panel principal
                        if (slot.transform.parent == merchantGrid)
                        {
                            slot.transform.SetParent(inventoryGrid, false);  // Déplace vers le panneau principal (main inventory)
                            Debug.Log("Slot déplacé vers le panneau principal (inventaire)");
                        }

                        // Réinitialise le Toggle après le déplacement
                        toggle.isOn = false;
                    }
                }
            }
            else
            {
                Debug.Log("Pas assez d'argent pour acheter ces objets !");
            }
        }

        public void SellSelectedItems()
        {
            int totalSaleValue = CalculateTotalSelectedItemsCost(); // Every item gives 1 money per quantity

            // Ajoute l'argent du joueur basé sur les objets sélectionnés
            PlayerController.moneyCount += totalSaleValue;
            UpdateMoneyUI();

            // Déplacer les objets vendus du panneau d'inventaire vers le panneau marchand
            foreach (GameObject slot in inventorySlots)
            {
                Toggle toggle = slot.GetComponentInChildren<Toggle>();
                if (toggle != null && toggle.isOn && slot.transform.parent == inventoryGrid)
                {
                    slot.transform.SetParent(merchantGrid, false);  // Déplace vers le panneau marchand
                    Debug.Log("Slot déplacé vers le panneau marchand (vente)");

                    toggle.isOn = false;  // Désactive le Toggle après la vente
                }
            }
            
            selectedItems.Clear();  // Nettoie la liste des objets sélectionnés
        }

        private int CalculateTotalSelectedItemsCost()
        {
            int totalCost = 0;

            foreach (var item in selectedItems)
            {
                totalCost += item.quantity;  // Assume each item costs 1 money per quantity
            }

            return totalCost;
        }

        public void UpdateMoneyUI()
        {
            if (moneyText != null)
            {
                moneyText.text = "Money: " + PlayerController.moneyCount;
            }
        }

        // Toggle item selection
        public void ToggleItemSelection(InventoryItem item, bool isSelected)
        {
            if (isSelected)
            {
                selectedItems.Add(item);
                Debug.Log("Objet sélectionné : " + item.itemName);
            }
            else
            {
                selectedItems.Remove(item);
                Debug.Log("Objet désélectionné : " + item.itemName);
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

        // Mark the item as bought (optional, to prevent re-buying)
        public void MarkItemAsBought(InventoryItem item)
        {
            // This is optional logic to handle the item after it's been bought.
            Debug.Log("Item " + item.itemName + " has been bought.");
        }

        public void PerformActionOnSelectedItems()
        {
            foreach (var item in selectedItems)
            {
                Debug.Log("Action sur l'objet : " + item.itemName);
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
