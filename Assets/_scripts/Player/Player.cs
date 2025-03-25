using UnityEngine;
using Photon.Pun;

namespace _scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviourPunCallbacks
    {
        [Header("Movement Settings")]
        [SerializeField] private float speed = 8f;
        [SerializeField] private float jumpForce = 12f;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;

        private Rigidbody2D _rb;
        [SerializeField] private bool _isGrounded;
        private float _horizontalInput;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!photonView.IsMine) return;
            FlipSprite();
        }

        public void Move(Vector2 movement)
        {
            if (photonView.IsMine)
            {
                _horizontalInput = movement.x;
                _rb.linearVelocity = new Vector2(movement.x * speed, _rb.linearVelocity.y);
            }
        }

        public void Jump()
        {
            if (photonView.IsMine)
            {
                if (_isGrounded)
                {
                    _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
                    _isGrounded = false;
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Floor"))
            {
                _isGrounded = true;
            }
        }

        private void FlipSprite()
        {
            if (_horizontalInput > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (_horizontalInput < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}