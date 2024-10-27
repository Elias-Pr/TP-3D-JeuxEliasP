using UnityEngine;

namespace UI_Marchand
{
    public class PlayerMovementMobile : MonoBehaviour
    {
        public Rigidbody rb;
        public float moveSpeed = 5f;
        
        private bool moveUp = false;
        private bool moveDown = false;
        private bool moveLeft = false;
        private bool moveRight = false;

        private void Start()
        {
            if (rb == null)
            {
                rb = GetComponent<Rigidbody>();
            }
        }

        private void Update()
        {
            if (moveUp)
            {
                Move(Vector3.forward);
            }
            if (moveDown)
            {
                Move(Vector3.back);
            }
            if (moveLeft)
            {
                Move(Vector3.left);
            }
            if (moveRight)
            {
                Move(Vector3.right);
            }
        }

        private void Move(Vector3 direction)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
        }

        public void OnButtonUpPress()
        {
            moveUp = true;
        }

        public void OnButtonUpRelease()
        {
            moveUp = false;
        }

        public void OnButtonDownPress()
        {
            moveDown = true;
        }

        public void OnButtonDownRelease()
        {
            moveDown = false;
        }

        public void OnButtonLeftPress()
        {
            moveLeft = true;
        }

        public void OnButtonLeftRelease()
        {
            moveLeft = false;
        }

        public void OnButtonRightPress()
        {
            moveRight = true;
        }

        public void OnButtonRightRelease()
        {
            moveRight = false;
        }
    }
}