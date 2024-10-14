using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private RectTransform joystickBackground;
    private RectTransform joystickHandle;
    private Vector2 inputVector;
    
    void Start()
    {
        // Get the RectTransforms of the joystick elements
        joystickBackground = GetComponent<RectTransform>();
        joystickHandle = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Get the position of the joystick background and calculate the input vector
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, eventData.position, eventData.pressEventCamera, out position);
        
        // Normalize the input and limit the movement of the joystick handle within the background
        position.x = (position.x / joystickBackground.sizeDelta.x) * 2;
        position.y = (position.y / joystickBackground.sizeDelta.y) * 2;
        inputVector = new Vector2(position.x, position.y);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
        
        // Move the handle
        joystickHandle.anchoredPosition = new Vector2(inputVector.x * (joystickBackground.sizeDelta.x / 2), inputVector.y * (joystickBackground.sizeDelta.y / 2));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);  // Start registering drag as soon as the user presses down
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Reset the handle position and input vector when the user releases the joystick
        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }

    // Method to get horizontal input
    public float Horizontal()
    {
        return inputVector.x;
    }

    // Method to get vertical input
    public float Vertical()
    {
        return inputVector.y;
    }
}
