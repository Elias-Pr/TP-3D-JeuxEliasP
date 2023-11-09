using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireComponent : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletTwo;
    public Transform GunOut;

    public int FirePower;
    public Image fire;
    public float cooldown = 4f;
    public float cooldownTwo = 8f;
    public bool FireOnCooldown = false;
    public bool FireOnCooldownTwo = false;
    
    public static Action onBlue;
    public static Action onRed;

    public static Action fireCooldown;

    private void Update() {
        
        if (Input.GetButtonDown("Fire1") && !FireOnCooldown) {
            GameObject ammoShot = Instantiate(bullet, GunOut.position, Quaternion.identity);
            ammoShot.GetComponent<Rigidbody>().AddForce(GunOut.forward * FirePower, ForceMode.Impulse);
            FireOnCooldown = true;
            Invoke(nameof(FireOnFalse), cooldown);
            onBlue.Invoke();
        }
        
        if (Input.GetButtonDown("Fire2") && !FireOnCooldownTwo) {
            GameObject ammoShot = Instantiate(bulletTwo, GunOut.position, Quaternion.identity);
            ammoShot.GetComponent<Rigidbody>().AddForce(GunOut.forward * FirePower, ForceMode.Impulse);
            FireOnCooldownTwo = true;
            Invoke(nameof(FireOnFalseTwo), cooldownTwo);
            onRed.Invoke();
        }
        
        if (Input.GetButtonDown("Fire1") && FireOnCooldown) {
            fireCooldown.Invoke();
        }
        
        if (Input.GetButtonDown("Fire2") && FireOnCooldownTwo) {
            fireCooldown.Invoke();
        }
        
        
    }
   
    private void FireOnFalse() {
        FireOnCooldown = false;
    }
    
    private void FireOnFalseTwo() {
        FireOnCooldownTwo = false;
    }
}