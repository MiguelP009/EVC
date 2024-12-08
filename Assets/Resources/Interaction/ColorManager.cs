using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace RVC {
public class ColorManager : MonoBehaviourPun
{

    public Renderer colorRenderer = null ;
    // Start is called before the first frame update
    void Start () {

           if (photonView.IsMine || ! PhotonNetwork.IsConnected) {

               float red = PlayerPrefs.GetFloat ("Red") ;

               float green = PlayerPrefs.GetFloat ("Green") ;

               float blue = PlayerPrefs.GetFloat ("Blue") ;

               colorRenderer.material.color = new Color (red, green, blue) ;

           } else {

               photonView.RPC ("SendMeTheColor", RpcTarget.Others) ;

               PhotonNetwork.SendAllOutgoingCommands () ;

           }

       }
    
    void SendMeTheColor (PhotonMessageInfo info) {

           if (photonView.IsMine || ! PhotonNetwork.IsConnected) {

               var c = colorRenderer.material.color ;

               Vector3 myVector = new Vector3 (c.r, c.g, c.b) ;

               photonView.RPC ("SetTheColor", RpcTarget.All, myVector) ;

               PhotonNetwork.SendAllOutgoingCommands () ;

           }

       }


       void SetTheColor (Vector3 myVector, PhotonMessageInfo info) {

           Color c = new Color (myVector [0], myVector [1], myVector [2]) ;

           colorRenderer.material.color = c ;

       }

    // Update is called once per frame

}
}