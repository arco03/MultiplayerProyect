using Photon.Pun;

namespace _scripts.Server
{
    public class ServerConnection : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        
        public override void OnConnected()
        {
            base.OnConnected();
        
            print("Is Connected!");
        }
        
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
        
            print("Is Connected To Master!");
        
            PhotonNetwork.JoinLobby();
        }
        
        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
        
            print("Has Joined To Lobby!");
        }
    }
}