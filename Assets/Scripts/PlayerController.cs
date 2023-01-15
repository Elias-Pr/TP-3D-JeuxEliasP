using System;
using UnityEngine;


public class PlayerController : MonoBehaviour {
  
  [SerializeField] private float speed;
  [SerializeField] private float jumpPower;
  [SerializeField] private float dashPower;
  
  public Rigidbody Rigidbody;
  public GroundDetection GroundDetection;
  public bool DashOnCooldown;

  

  

    private void Update() {
    if (Input.GetKeyDown(KeyCode.E) && !DashOnCooldown) {
      Rigidbody.AddForce(transform.forward * dashPower);
      DashOnCooldown = true;
      Invoke(nameof(DashOnFalse), 4f);
    }

    
    
    if(Input.GetButtonDown("Jump") && GroundDetection.IsCollided) {
      Rigidbody.AddForce(transform.up * jumpPower);
    }
    
  }

  private void FixedUpdate() {
    float xMov = Input.GetAxisRaw(("Horizontal"));
    float zMov = Input.GetAxisRaw(("Vertical"));
    Vector3 velocity = transform.TransformDirection(new Vector3(xMov, 0, zMov).normalized) * (speed * Time.fixedDeltaTime);
    Rigidbody.velocity = new Vector3(velocity.x, Rigidbody.velocity.y, velocity.z);
  }

  private void DashOnFalse() {
    DashOnCooldown = false;
  }
  
}
