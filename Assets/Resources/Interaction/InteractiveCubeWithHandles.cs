using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class In : MonoBehaviourPun
{
    // Start is called before the first frame update
    public GameObject topHandle ;

    public GameObject bottomHandle ;

    public GameObject leftHandle ;

    public GameObject rightHandle ;

    public GameObject frontHandle ;

    public GameObject backHandle ;

    void ComputePosition () {

            transform.position = (topHandle.transform.position +

                                    bottomHandle.transform.position +

                                    leftHandle.transform.position +

                                    rightHandle.transform.position +

                                    frontHandle.transform.position +

                                    backHandle.transform.position) / 6 ;

    }

    // Update is called once per frame
    void Update () {

        if (photonView.IsMine) {

            ComputePosition () ;

        }

    }
}
