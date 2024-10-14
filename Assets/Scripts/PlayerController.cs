using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for Button

public class PlayerController : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float recoilPower;
    [SerializeField] private float dashPower;

    // Reference to the Joystick script for mobile controls
    public Joystick joystick;

    // Button for jump action (for mobile)
    public Button jumpButton;

    public Rigidbody Rigidbody;
    public GroundDetection GroundDetection;
    public bool DashOnCooldown;

    public AudioClip clipToPlayMenu;

    public static Action onJump;

    private void Start() {
        // Add a listener for the jump button (mobile)
        if (jumpButton != null) {
            jumpButton.onClick.AddListener(PerformJump);
        }
    }

    private void Update() {
        // Handle Esc key to go back to the main menu
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = true;
            Destroy(AudioManager.Instance.gameObject);
            Invoke(nameof(mainMenu), 0f);
        }

        // Handle Jump input (keyboard)
        if (Input.GetButtonDown("Jump") && GroundDetection.IsCollided) {
            PerformJump();
        }
    }

    private void FixedUpdate() {
        // Handle keyboard input
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        // Handle joystick input (optional, if a joystick is assigned)
        if (joystick != null) {
            xMov = joystick.Horizontal() != 0 ? joystick.Horizontal() : xMov;
            zMov = joystick.Vertical() != 0 ? joystick.Vertical() : zMov;
        }

        // Move the player based on the input (keyboard or joystick)
        Vector3 velocity = transform.TransformDirection(new Vector3(xMov, 0, zMov).normalized) * (speed * Time.fixedDeltaTime);
        Rigidbody.velocity = new Vector3(velocity.x, Rigidbody.velocity.y, velocity.z);
    }

    // Method that performs the jump
    public void PerformJump() {
        if (GroundDetection.IsCollided) {
            Rigidbody.AddForce(transform.up * jumpPower);
            onJump?.Invoke();
        }
    }

    private void DashOnFalse() {
        DashOnCooldown = false;
    }

    public void mainMenu() {
        SceneManager.LoadScene("GameMenu");
    }
}
