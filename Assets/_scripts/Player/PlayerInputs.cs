using UnityEngine;
using Photon.Pun;

namespace _scripts.Player
{
    public class PlayerInputs : MonoBehaviourPunCallbacks
    {
        [Header("Control Settings")] 
        [SerializeField] private string horizontal;
        [SerializeField] private string vertical;

        [SerializeField] private Player player;
        private Vector2 _movement;

        private void Update()
        {
            if (photonView.IsMine)
            {
                _movement.x = Input.GetAxisRaw(horizontal);
                _movement.y = Input.GetAxisRaw(vertical);
            }
        }

        private void FixedUpdate()
        {
            if (photonView.IsMine)
            {
                player.Move(_movement);
            }
        }
    }
}