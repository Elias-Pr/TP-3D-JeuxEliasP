using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : Plateform
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }
        other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 400);
        Debug.Log("camarche");
    }
    
}
