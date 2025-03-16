using _scripts.Generics;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviourPunCallbacks
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
            MessagePanel.Instance.ShowMessage("La sala está llena!");
            Debug.Log("No more players");
            return;
        }
            
        string prefabToInstantiate;

        if (playerIndex == 0) // Primer jugador que entra
        {
            // Elegir un prefab aleatorio y guardarlo en Custom Properties
            prefabToInstantiate = Random.Range(0, 2) == 0 ? "Player1" : "Player2";
            Hashtable properties = new Hashtable { { "SelectedPrefab", prefabToInstantiate } };
            PhotonNetwork.CurrentRoom.SetCustomProperties(properties);
        }
        else // Segundo jugador
        {
            // Obtener el prefab del primer jugador y usar el otro
            string firstPlayerPrefab = (string)PhotonNetwork.CurrentRoom.CustomProperties["SelectedPrefab"];
            prefabToInstantiate = firstPlayerPrefab == "Player1" ? "Player2" : "Player1";
        }

        Vector3 spawnPos = spawnPoints[playerIndex];
        PhotonNetwork.Instantiate(prefabToInstantiate, spawnPos, Quaternion.identity, 0);
    }
}
