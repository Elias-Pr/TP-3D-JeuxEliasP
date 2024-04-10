using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : Plateform
{
    public static Action playerBounce;
    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        other.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 400);
        
        
    }
    
	private void OnCollisionExit(Collision other){
        
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
	    playerBounce.Invoke();

	}

}
