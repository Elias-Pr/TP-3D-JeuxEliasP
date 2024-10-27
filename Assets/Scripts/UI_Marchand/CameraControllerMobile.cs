using UnityEngine;

public class PlayerControllerMobile : MonoBehaviour
{
    public float rotationSpeed = 50f;

    private bool rotateUp = false;
    private bool rotateDown = false;
    private bool rotateLeft = false;
    private bool rotateRight = false;

    private void Update()
    {
        if (rotateUp)
        {
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        }
        if (rotateDown)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
        if (rotateLeft)
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
        if (rotateRight)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }

    public void OnButtonUpPress()
    {
        rotateUp = true;
    }

    public void OnButtonUpRelease()
    {
        rotateUp = false;
    }

    public void OnButtonDownPress()
    {
        rotateDown = true;
    }

    public void OnButtonDownRelease()
    {
        rotateDown = false;
    }

    public void OnButtonLeftPress()
    {
        rotateLeft = true;
    }

    public void OnButtonLeftRelease()
    {
        rotateLeft = false;
    }

    public void OnButtonRightPress()
    {
        rotateRight = true;
    }

    public void OnButtonRightRelease()
    {
        rotateRight = false;
    }
}
