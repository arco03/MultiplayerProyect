using _scripts.Generics;
using Photon.Pun;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;

namespace _scripts.Player
{
    public class PlayerSpawner : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Vector3[] spawnPoints;
        [SerializeField] private PhotonView photonView; // Asignar en el Inspector

        private string playerPrefab;

        private void Start()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                // Elige el prefab aleatoriamente
                playerPrefab = Random.Range(0, 2) == 0 ? "Player1" : "Player2";

                // Llama al RPC para sincronizar con el segundo jugador
                photonView.RPC("SetPlayerPrefab", RpcTarget.OthersBuffered, playerPrefab);

                // Genera al primer jugador
                SpawnPlayer(0);
            }
        }

        [PunRPC]
        private void SetPlayerPrefab(string prefabName)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                // Asigna el prefab opuesto al segundo jugador
                playerPrefab = (prefabName == "Player1") ? "Player2" : "Player1";
                SpawnPlayer(1);
            }
        }

        private void SpawnPlayer(int spawnIndex)
        {
            Vector3 spawnPos = spawnPoints[spawnIndex];
            PhotonNetwork.Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        }
    }
}
    

