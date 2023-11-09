using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TranslatePlateform : MonoBehaviour
{
    public bool TranslationReverse;
    public float ReverseDelay = 5f;

    
    
    void Update()
    {
        
        
        if (TranslationReverse)
        {
            transform.Translate(0, 0, Time.deltaTime);
            transform.Translate(0, -Time.deltaTime, 0, Space.World);
            Invoke(nameof(Reverse),ReverseDelay);
        }

        else
        {
            transform.Translate(0, 0, -Time.deltaTime);
            transform.Translate(0, Time.deltaTime, 0, Space.World);
            Invoke(nameof(CounterReverse),ReverseDelay);
        }
    }

    

    private void Reverse()
    {
        TranslationReverse = false;
    }
    private void CounterReverse()
    {
        TranslationReverse = true;
    }
}
