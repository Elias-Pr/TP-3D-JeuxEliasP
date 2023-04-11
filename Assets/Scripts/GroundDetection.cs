using System;
using UnityEngine;

public class GroundDetection : MonoBehaviour {

    public bool IsCollided;
    
    /*private void OnTriggerEnter(Collider other) {
        IsCollided = true;
        Debug.Log("Ground Collider enter" + other.gameObject.name);
    }*/

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Ground"))
        {
            IsCollided = false;
        }
        //Debug.Log("Ground Collider exit" + other.gameObject.name);
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Ground"))
        {
            IsCollided = true;
        }
        //Debug.Log("Ground Collider enter" + other.gameObject.name);
    }
    
}
