using UnityEngine;
using Photon.Pun;

namespace _scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviourPunCallbacks
    {
        [SerializeField] private float speed;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 movement)
        {
            if (photonView.IsMine)
            {
                _rb.linearVelocity = movement.normalized * speed;
            }
        }
    }
}