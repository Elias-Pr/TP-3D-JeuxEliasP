using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{

    public static Action playerDeath;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playerDeath.Invoke();
                SceneManager.LoadScene("Game");
                
            }
           
        }
    
}
