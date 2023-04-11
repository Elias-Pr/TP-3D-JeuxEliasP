using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{

    private void OnTriggerStay(Collider col) {
        if (col.CompareTag("Player"))
        {
            col.transform.parent = transform;
        }
        //Debug.Log("Player Collider enter" + col.gameObject.name);
    }
    
    private void OnTriggerExit(Collider col) {
        if (col.CompareTag("Player"))
        {
            col.transform.parent = null;
        }
        //Debug.Log("Player Collider exit" + col.gameObject.name);
    }
}
