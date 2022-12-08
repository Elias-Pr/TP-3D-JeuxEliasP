using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// A simple FPP (First Person Perspective) camera rotation script.
/// Like those found in most FPS (First Person Shooter) games.
/// </summary>
public class CameraRotation : MonoBehaviour {

    [SerializeField] private bool xRotation;
    [SerializeField] private bool yRotation;

    [Range(0.1f, 9f)][SerializeField] float sensitivity;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [Range(0f, 90f)][SerializeField] float xRotationLimit;
    
    void Update() {
        Vector3 rotation = new Vector3();
        if (yRotation) rotation.y += Input.GetAxis("Mouse X") * sensitivity;
        if (xRotation) rotation.x += -Input.GetAxis("Mouse Y") * sensitivity;
        rotation.x = Mathf.Clamp(rotation.x, -xRotationLimit, xRotationLimit);
        transform.Rotate(rotation);
    }
    
}