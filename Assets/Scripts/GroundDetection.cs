using UnityEngine;

public class GroundDetection : MonoBehaviour {

    public bool IsCollided;
    
    private void OnTriggerEnter(Collider other) {
        IsCollided = true;
        Debug.Log("Ground Collider enter" + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other) {
        IsCollided = false;
        Debug.Log("Ground Collider exit" + other.gameObject.name);
    }
    
}
