using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Called when dragging begins
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; // Store the original parent
        transform.SetParent(transform.root); // Move the item to the root to avoid masking issues
        canvasGroup.blocksRaycasts = false; // Disable raycasting so it doesn't interfere with other UI
        canvasGroup.alpha = 0.6f; // Make the item slightly transparent while dragging
    }

    // Called when the item is being dragged
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / GetCanvasScaleFactor(); // Move the item
    }

    // Called when dragging ends
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Enable raycasting again
        canvasGroup.alpha = 1.0f; // Reset transparency

        // If the item is not dropped on a valid slot, return it to its original position
        if (transform.parent == transform.root)
        {
            transform.SetParent(originalParent);
        }
    }

    // Helper function to adjust for Canvas scaling
    private float GetCanvasScaleFactor()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        return canvas != null ? canvas.scaleFactor : 1f;
    }
}