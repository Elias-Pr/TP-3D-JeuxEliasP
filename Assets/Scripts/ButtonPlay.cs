using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void doExitGame() {
        Application.Quit();
        Debug.Log("Game is exiting"); //vérification de la fonctionalitée
        
    }
    
}
