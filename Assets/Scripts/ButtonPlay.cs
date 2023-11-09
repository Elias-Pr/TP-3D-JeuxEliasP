using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public AudioClip clipToPlayGame;

    public static Action launch;
    
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
        AudioManager.Instance.ChangeAudioClip(clipToPlayGame);
        
        launch.Invoke();
    }
    
    public void doExitGame() {
        Application.Quit();
        
    }
    
}
