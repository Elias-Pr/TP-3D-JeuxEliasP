using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Prefabs
{
    public class InventoryManager : MonoBehaviour
    {
        public GameObject inventorySlotPrefab;  // Prefab pour les slots d'inventaire
        public Transform inventoryGrid;         // Le parent contenant la grille d'inventaire
        public Transform secondaryPanel;        // Le parent secondaire (autre panneau)

        private List<GameObject> inventorySlots = new List<GameObject>(); // Liste des slots d'inventaire
        private List<InventoryItem> inventoryItems = new List<InventoryItem>();
        private List<InventoryItem> selectedItems = new List<InventoryItem>();

        void Start()
        {
            AddItemToInventory("Potion", 1);
            AddItemToInventory("Épée", 1);
            AddItemToInventory("Bouclier", 1);
        }
        
        public void AddItemToInventory(string itemName, int quantity)
        {
            InventoryItem newItem = new InventoryItem(itemName, quantity);
            inventoryItems.Add(newItem);
    
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryGrid); // Add to the first panel
            inventorySlots.Add(slot); // Add the slot to the list of slots
    
            Button button = slot.GetComponentInChildren<Button>();
            button.GetComponentInChildren<TMP_Text>().text = newItem.itemName;

            // Add the drag-and-drop handler to the slot
            slot.AddComponent<DraggableItem>();

            // Add a listener to the button for item selection
            button.onClick.AddListener(() => MoveSelectedItemsToSecondaryPanel());

            Toggle toggle = slot.GetComponentInChildren<Toggle>();
            toggle.onValueChanged.AddListener(isOn => ToggleItemSelection(newItem, isOn));
        }

        public void MoveSelectedItemsToSecondaryPanel()
        {
            // Pour chaque slot dans l'inventaire
            foreach (GameObject slot in inventorySlots)
            {
                // Vérifie si le Toggle est activé
                Toggle toggle = slot.GetComponentInChildren<Toggle>();
                if (toggle != null && toggle.isOn)
                {
                    // Vérifie si le slot est dans le panel principal et le déplace
                    if (slot.transform.parent == inventoryGrid)
                    {
                        slot.transform.SetParent(secondaryPanel, false);  // Déplace vers le panel secondaire
                        Debug.Log("Slot déplacé vers le panneau secondaire");
                    }
                    else
                    {
                        slot.transform.SetParent(inventoryGrid, false);  // Remet dans le panel principal
                        Debug.Log("Slot remis dans le panneau principal");
                    }

                    // Réinitialise le Toggle après le déplacement
                    toggle.isOn = false;
                }
            }
        }

        public void UseItem(InventoryItem item)
        {
            Debug.Log("Utilisation de l'objet : " + item.itemName);
            // Ici, tu peux définir l'action à effectuer (comme utiliser l'objet ou l'équiper)
        }
        
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
