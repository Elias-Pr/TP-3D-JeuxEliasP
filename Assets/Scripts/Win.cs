using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public AudioClip clipToPlayEnd;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameEnd");
            AudioManager.Instance.ChangeAudioClip(clipToPlayEnd);
        }
           
    }
}
