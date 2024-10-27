using System;
using UnityEngine;
using UnityEngine.UI;

public class FireComponent : MonoBehaviour {

    public GameObject bullet;
    public GameObject bulletTwo;
    public Transform GunOut;

    public int FirePower;
    public float cooldown = 4f;
    public float cooldownTwo = 8f;
    public bool FireOnCooldown = false;
    public bool FireOnCooldownTwo = false;
    
    public static Action onBlue;
    public static Action onRed;
    public static Action fireCooldown;

    public Button blueFireButton;
    public Button redFireButton;

    private void Start() {
        blueFireButton.onClick.AddListener(OnBlueFireButtonClick);
        redFireButton.onClick.AddListener(OnRedFireButtonClick);
    }

    private void Update() {
        if (GameMaster.IsMenuOpen)
        {
            return;
        }
        
        /*
        if (Input.GetButtonDown("Fire1") && !FireOnCooldown) {
            FireBlueBullet();
        }
        
        if (Input.GetButtonDown("Fire2") && !FireOnCooldownTwo) {
            FireRedBullet();
        }

        if (Input.GetButtonDown("Fire1") && FireOnCooldown) {
            fireCooldown?.Invoke();
        }

        if (Input.GetButtonDown("Fire2") && FireOnCooldownTwo) {
            fireCooldown?.Invoke();
        }
        */
    }

    private void OnBlueFireButtonClick() {
        if (!FireOnCooldown) {
            FireBlueBullet();
        } else {
            fireCooldown?.Invoke();
        }
    }

    private void OnRedFireButtonClick() {
        if (!FireOnCooldownTwo) {
            FireRedBullet();
        } else {
            fireCooldown?.Invoke();
        }
    }

    private void FireBlueBullet() {
        GameObject ammoShot = Instantiate(bullet, GunOut.position, Quaternion.identity);
        ammoShot.GetComponent<Rigidbody>().AddForce(GunOut.forward * FirePower, ForceMode.Impulse);
        FireOnCooldown = true;
        Invoke(nameof(FireOnFalse), cooldown);
        onBlue?.Invoke();
    }

    private void FireRedBullet() {
        GameObject ammoShot = Instantiate(bulletTwo, GunOut.position, Quaternion.identity);
        ammoShot.GetComponent<Rigidbody>().AddForce(GunOut.forward * FirePower, ForceMode.Impulse);
        FireOnCooldownTwo = true;
        Invoke(nameof(FireOnFalseTwo), cooldownTwo);
        onRed?.Invoke();
    }

    private void FireOnFalse() {
        FireOnCooldown = false;
    }

    private void FireOnFalseTwo() {
        FireOnCooldownTwo = false;
    }
}
