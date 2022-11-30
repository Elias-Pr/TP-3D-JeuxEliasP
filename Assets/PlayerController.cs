using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
  [SerializeField] 
  private float speed;

  private PlayerMotor motor;
  

  public float JumPower;
  public Rigidbody Rigidbody;
  

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
    
    if(Input.GetButtonDown("Jump"))
    {
      Rigidbody.AddForce(Vector3.up*JumPower);
    }
  }
}
