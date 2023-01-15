using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireComponent : MonoBehaviour {

    public GameObject bullet;
    public Transform GunOut;

    public int FirePower;
    public Image fire;
    public float cooldown = 4f;
    public bool FireOnCooldown = false;

    private void Update() {
        
        if (Input.GetButtonDown("Fire1") && !FireOnCooldown) {
            GameObject ammoShot = Instantiate(bullet, GunOut.position, Quaternion.identity);
            ammoShot.GetComponent<Rigidbody>().AddForce(GunOut.forward * FirePower, ForceMode.Impulse);
            FireOnCooldown = true;
            Invoke(nameof(FireOnFalse), cooldown);
        }
    }
   
    private void FireOnFalse() {
        FireOnCooldown = false;
    }
}