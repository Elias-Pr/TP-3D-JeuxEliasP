using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPose : MonoBehaviour
{

    private GameMaster gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }

    
}
