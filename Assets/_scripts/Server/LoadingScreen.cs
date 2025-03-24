using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _scripts.Server
{
    public class LoadingScreen : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Button cancelButton;

        private void Start()
        {
            cancelButton.onClick.AddListener(OnCancelButtonClicked);
        }

        private void OnCancelButtonClicked()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            SceneManager.LoadScene("Rooms");
        }

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                PhotonNetwork.LoadLevel("Game");
            }
        }
    }
}