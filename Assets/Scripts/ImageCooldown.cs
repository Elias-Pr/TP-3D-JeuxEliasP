using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageCooldown : MonoBehaviour
{
    public Image dashicon;
    public float cooldown = 4f;
    public bool DashOnCooldown = false;
    public KeyCode TheKey;
    
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(TheKey) && !DashOnCooldown)
        {
            DashOnCooldown = true;
            dashicon.fillAmount = 0;

        }
        
        if(DashOnCooldown)
        {

            dashicon.fillAmount += 1 / cooldown * Time.deltaTime;

            if (dashicon.fillAmount >= 1)
            {
                dashicon.fillAmount = 1;
                DashOnCooldown = false;

            }
        }

        
        
    }
    
    
}
