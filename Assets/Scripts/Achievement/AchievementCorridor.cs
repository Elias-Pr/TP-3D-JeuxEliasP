using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementCorridor : MonoBehaviour
{
    public static Action plateformTranslation;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("yes");
            plateformTranslation.Invoke();
        }
    }
}
