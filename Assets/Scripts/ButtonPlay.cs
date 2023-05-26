using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public AudioClip clipToPlayGame;
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
        AudioManager.Instance.ChangeAudioClip(clipToPlayGame);
    }
    
    public void doExitGame() {
        Application.Quit();
        Debug.Log("Game is exiting"); //vérification de la fonctionalitée
        
    }
    
}
