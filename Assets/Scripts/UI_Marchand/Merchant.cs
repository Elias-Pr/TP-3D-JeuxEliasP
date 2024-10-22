using System;
using UnityEngine;

namespace UI_Marchand
{
    public class Merchant : MonoBehaviour
    {
        public Canvas tradeUI;
    
        void Start()
        {
            tradeUI.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                tradeUI.enabled = true; 
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                GameMaster.IsMenuOpen = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                tradeUI.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                GameMaster.IsMenuOpen = false;
            }
        }
    }
}
