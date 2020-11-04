using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public BallMovement ballMv;
    public EnvActivation ENV;
    public CameraMovement camMove;

    public GameManager GM;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "walls")
        {
            GM.isGameover = true;
            ENV.StartCoroutine("PlayballBlast");
            this.gameObject.SetActive(false);
            ballMv.ismoving = false;
            GM.isPlaymode = false;
            GM.StartCoroutine("RestartLevel");
        }

        if (other.tag == "way")
        {
            other.transform.gameObject.SetActive(false);
        }        

        if(other.tag == "initdest")
        {
            //if(GM.LoadLevel >= 5)
            //{
                
            //}
            camMove.StartCoroutine("MoveCamTo");
            ENV.PlayballReachPoint(other.transform.gameObject);
            other.transform.gameObject.SetActive(false);
        }

        if (other.tag == "Finaldest")
        {
            ENV.PlayballFinalReach(other.transform.gameObject);
            other.transform.gameObject.SetActive(false);
            GM.isPlaymode = false;
            GM.StartCoroutine("LoadnextLevel");
        }

    }
}
