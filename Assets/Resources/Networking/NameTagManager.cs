using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

namespace CustomNamespace
{
    public class PlayerNameDisplay : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private TMP_Text nameTag = null;

        private void Awake()
        {
            if (nameTag == null)
            {
                Debug.LogError("Name text component is not assigned.");
            }
        }

        private void Start()
        {
            if (photonView.IsMine || !PhotonNetwork.IsConnected)
            {
                AssignPlayerName();
            }
            else
            {
                photonView.RPC("RequestPlayerName", RpcTarget.OthersBuffered);
            }
        }

        private void AssignPlayerName()
        {
            string playerName = PlayerPrefs.GetString("PlayerName", "Unknown");
            nameTag.text = playerName;
            photonView.RPC("BroadcastPlayerName", RpcTarget.AllBuffered, playerName);
        }

        [PunRPC]
        private void RequestPlayerName(PhotonMessageInfo senderInfo)
        {
            if (photonView.IsMine)
            {
                photonView.RPC("BroadcastPlayerName", senderInfo.Sender, nameTag.text);
            }
        }

        [PunRPC]
        private void BroadcastPlayerName(string playerName)
        {
            nameTag.text = playerName;
        }
    }
}
