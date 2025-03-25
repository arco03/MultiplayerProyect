using System;
using UnityEngine;
using Photon.Pun;

namespace _scripts.Player
{
    public class PlayerInputs : MonoBehaviourPunCallbacks
    {
        [Header("Control Settings")]
        [SerializeField] private string horizontal = "Horizontal";

        [SerializeField] private Player player;
        private Vector2 _movement;

        private void Update()
        {
            if (!photonView.IsMine) return;

            HandleInput();
        }

        private void HandleInput()
        {
            _movement.x = Input.GetAxisRaw(horizontal);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.Jump();
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