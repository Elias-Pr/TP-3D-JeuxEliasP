using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedItem = eventData.pointerDrag; // The item being dragged
        if (droppedItem != null)
        {
            DraggableItem draggableItem = droppedItem.GetComponent<DraggableItem>();
            if (draggableItem != null)
            {
                // Set the item's parent to this panel and reset its position
                droppedItem.transform.SetParent(transform, false);
                Debug.Log("Item dropped in the new area");
            }
        }
    }
}