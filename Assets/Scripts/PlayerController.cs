using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
  
  [SerializeField] 
  private float speed;

  private PlayerMotor motor;
  

  public float JumPower;
  public float DashPower;
  public Rigidbody Rigidbody;
  public GroundDetection GroundDetection;
  public bool DashOnCooldown = false;
  

  private void Start()
  {
    motor = GetComponent<PlayerMotor>();
  }

  private void Update() 
  {
    float xMov = Input.GetAxisRaw(("Horizontal"));
    float zMov = Input.GetAxisRaw(("Vertical"));

    Vector3 moveHorizontal = transform.right * xMov;
    Vector3 moveVertical = transform.forward * zMov;

    Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

    motor.Move(velocity);
    
    if (Input.GetKeyDown(KeyCode.E) && !DashOnCooldown) {
      Rigidbody.AddForce(transform.forward * DashPower);
      DashOnCooldown = true;
      Invoke(nameof(DashOnFalse), 3f);
    }
    
    if(Input.GetButtonDown("Jump") && GroundDetection.IsCollided)
    {
      Rigidbody.AddForce(transform.up*JumPower);
    }
  }

  private void DashOnFalse() {
    DashOnCooldown = false;
  }
  
}
