using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace _scripts.Server
{
    public class Rooms : MonoBehaviourPunCallbacks
    {
        [SerializeField] public TMP_InputField createRoomInputField, joinedRoomInputField;
        [SerializeField] private string roomName;

        private void Start()
        {
            createRoomInputField?.onValueChanged.AddListener(text => { roomName = text;});
            joinedRoomInputField?.onValueChanged.AddListener(text => { roomName = text;});
        }

        [ContextMenu("Create")]
        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2;
            
            PhotonNetwork.CreateRoom(roomName, roomOptions);
        }

        [ContextMenu("Join")]
        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(roomName);
        }

        [ContextMenu("Leave")]
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnCreatedRoom()
        {
            base.OnCreatedRoom();

            print("Room Created!");
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            base.OnCreateRoomFailed(returnCode, message);

            print($"Room Creation Failed!\nCode: {returnCode} Error: {message}");
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();

            print($"Has Connected To Room {PhotonNetwork.CurrentRoom.Name}!");
            PhotonNetwork.LoadLevel("Game");
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            base.OnJoinRoomFailed(returnCode, message);

            print($"Room Connection Failed!\nCode: {returnCode} Error: {message}");
        }

        public override void OnLeftRoom()
        {
            base.OnLeftRoom();

            print("Has Left The Room!");
        }
    }
}