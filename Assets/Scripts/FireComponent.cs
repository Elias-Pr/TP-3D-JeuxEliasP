using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireComponent : MonoBehaviour {

    public GameObject bullet;
    public Transform GunOut;

    public int FirePower;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            GameObject ammoShot = Instantiate(bullet, GunOut.position, Quaternion.identity);
            ammoShot.GetComponent<Rigidbody>().AddForce(GunOut.forward * FirePower, ForceMode.Impulse);
        }
    }
   
}