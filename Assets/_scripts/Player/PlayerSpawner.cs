using Photon.Pun;
using UnityEngine;

namespace _scripts.Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Vector3[] spawnPoints;

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            int playerIndex = PhotonNetwork.CurrentRoom.PlayerCount -1;
            if (playerIndex >= spawnPoints.Length)
            {
                Debug.Log("No more players");
                return;
            }
            
            Vector3 spawnPos = spawnPoints[playerIndex];
            PhotonNetwork.Instantiate("Player", spawnPos, Quaternion.identity, 0);
        }
    }
}