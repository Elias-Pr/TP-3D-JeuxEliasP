using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : Achievment.MonoBehaviourSingleton<AchievementController>
{
    private int jumpCount = 0;

    private Action<int> onJumpCountChange;

    public void RegisterJumpCountChangeListener(Action<int> listener)
    {
        onJumpCountChange += listener;
    }

    public void UnregisterJumpCountChangeListener(Action<int> listener)
    {
        onJumpCountChange -= listener;
    }

    public void PlayerJumped()
    {
        jumpCount++;
        Debug.Log("Jump count: " + jumpCount);

        if (onJumpCountChange != null)
        {
            onJumpCountChange(jumpCount);

            if (jumpCount == 5)
            {
                Debug.Log("Mario Like");
            }
            
            if (jumpCount == 10)
            {
                Debug.Log("SUPER Mario Like");
            }
        }
    }
}