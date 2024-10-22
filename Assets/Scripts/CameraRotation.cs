using System;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    [SerializeField] private bool xRotation;
    [SerializeField] private bool yRotation;

    [Range(0.1f, 9f)][SerializeField] float sensitivity;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float xRotationLimit;

    // Reference to a second joystick for camera control
    public Joystick cameraJoystick;

    private float xRotationValue = 0f;

    

    private void Start() {
        // Hide the cursor and lock it to the center of the screen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {

        if (GameMaster.IsMenuOpen)
        {
            return;
        }
        
        Vector3 rotation = new Vector3();

        // Handle mouse input
        if (yRotation) rotation.y += Input.GetAxis("Mouse X") * sensitivity;
        if (xRotation) rotation.x += -Input.GetAxis("Mouse Y") * sensitivity;

        // Handle joystick input (if a joystick is assigned)
        if (cameraJoystick != null) {
            if (yRotation) rotation.y += cameraJoystick.Horizontal() * sensitivity;
            if (xRotation) rotation.x += -cameraJoystick.Vertical() * sensitivity;
        }

        // Clamp the X rotation to prevent flipping
        xRotationValue = Mathf.Clamp(xRotationValue + rotation.x, -xRotationLimit, xRotationLimit);

        // Apply the X and Y rotation
        transform.localEulerAngles = new Vector3(xRotationValue, transform.localEulerAngles.y + rotation.y, 0);
    }
}