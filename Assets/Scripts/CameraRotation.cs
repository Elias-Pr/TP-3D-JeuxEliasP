using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotation : MonoBehaviour {

    [SerializeField] private bool xRotation;
    [SerializeField] private bool yRotation;

    [Range(0.1f, 9f)][SerializeField] float sensitivity;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float xRotationLimit;

    private float xRotationValue = 0f;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {

        if (GameMaster.IsMenuOpen)
        {
            return;
        }
        
        Vector3 rotation = new Vector3();

        if (yRotation) rotation.y += Input.GetAxis("Mouse X") * sensitivity;
        if (xRotation) rotation.x += -Input.GetAxis("Mouse Y") * sensitivity;

        xRotationValue = Mathf.Clamp(xRotationValue + rotation.x, -xRotationLimit, xRotationLimit);

        transform.localEulerAngles = new Vector3(xRotationValue, transform.localEulerAngles.y + rotation.y, 0);
    }
}