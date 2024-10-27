using System;
using charlieMusic;
using UI_Marchand;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    public static int moneyCount;

    public Button jumpButton;

    public Rigidbody Rigidbody;
    public GroundDetection GroundDetection;

    public static Action onJump;

    private void Start() {
        if (jumpButton != null) {
            jumpButton.onClick.AddListener(PerformJump);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.visible = true;
            Destroy(AudioManager.Instance.gameObject);
            Invoke(nameof(mainMenu), 0f);
        }

        if (Input.GetButtonDown("Jump") && GroundDetection.IsCollided) {
            PerformJump();
        }
    }

    private void FixedUpdate()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        // Move the player based on the input (keyboard or joystick)
        Vector3 velocity = transform.TransformDirection(new Vector3(xMov, 0, zMov).normalized) * (speed * Time.fixedDeltaTime);
        Rigidbody.velocity = new Vector3(velocity.x, Rigidbody.velocity.y, velocity.z);
    }

    public void PerformJump() {
        if (GroundDetection.IsCollided) {
            Rigidbody.AddForce(transform.up * jumpPower);
            onJump?.Invoke();
        }
    }

    public void mainMenu() {
        SceneManager.LoadScene("GameMenu");
    }
}
