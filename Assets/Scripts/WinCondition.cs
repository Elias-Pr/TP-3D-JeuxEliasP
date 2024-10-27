using System;
using System.Collections;
using System.Collections.Generic;
using charlieMusic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public static Action playerWin;
    
    public AudioClip clipToPlayEnd;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameEnd");
            AudioManager.Instance.ChangeAudioClip(clipToPlayEnd);
            
            playerWin.Invoke();
            
        }
           
    }
}
