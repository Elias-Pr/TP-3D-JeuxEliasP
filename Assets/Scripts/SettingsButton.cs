using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject settingsCanvas; // Reference to the settings canvas

    // Method to toggle the canvas on and off
    public void ToggleSettingsCanvas()
    {
        if (settingsCanvas != null)
        {
            bool isActive = settingsCanvas.activeSelf; // Check current state
            settingsCanvas.SetActive(!isActive);       // Toggle the state
        }
    }
    
}
