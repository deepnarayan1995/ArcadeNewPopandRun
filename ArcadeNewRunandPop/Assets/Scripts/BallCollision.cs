using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public Player PL;

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
            camMove.StartCoroutine("MoveCamTo");
            ENV.PlayballReachPoint(other.transform.gameObject);
            other.transform.gameObject.SetActive(false);
        }

        if (other.tag == "Finaldest")
        {
            if(other.name == "F1" && PL.totalLevelLocked == 39)
            {
                PL.LoadLevel = 1;
                PL.totalLevelLocked = 38;
                GM.SaveThisGame();
            }
            else if (other.name == "F2" && PL.totalLevelLocked == 38)
            {
                PL.LoadLevel = 2;
                PL.totalLevelLocked = 37;
                GM.SaveThisGame();
            }
            else if (other.name == "F3" && PL.totalLevelLocked == 37)
            {
                PL.LoadLevel = 3;
                PL.totalLevelLocked = 36;
                GM.SaveThisGame();
            }
            else if (other.name == "F4" && PL.totalLevelLocked == 36)
            {
                PL.LoadLevel = 4;
                PL.totalLevelLocked = 35;
                GM.SaveThisGame();
            }
            else if (other.name == "F5" && PL.totalLevelLocked == 35)
            {
                PL.LoadLevel = 5;
                PL.totalLevelLocked = 34;
                GM.SaveThisGame();
            }
            else if (other.name == "F6" && PL.totalLevelLocked == 34)
            {
                PL.LoadLevel = 6;
                PL.totalLevelLocked = 33;
                GM.SaveThisGame();
            }
            else if (other.name == "F7" && PL.totalLevelLocked == 33)
            {
                PL.LoadLevel = 7;
                PL.totalLevelLocked = 32;
                GM.SaveThisGame();
            }
            else if (other.name == "F8" && PL.totalLevelLocked == 32)
            {
                PL.LoadLevel = 8;
                PL.totalLevelLocked = 31;
                GM.SaveThisGame();
            }
            else if (other.name == "F9" && PL.totalLevelLocked == 31)
            {
                PL.LoadLevel = 9;
                PL.totalLevelLocked = 30;
                GM.SaveThisGame();
            }
            else if (other.name == "F10" && PL.totalLevelLocked == 30)
            {
                PL.LoadLevel = 10;
                PL.totalLevelLocked = 29;
                GM.SaveThisGame();
            }
            else if (other.name == "F11" && PL.totalLevelLocked == 29)
            {
                PL.LoadLevel = 11;
                PL.totalLevelLocked = 28;
                GM.SaveThisGame();
            }
            else if (other.name == "F12" && PL.totalLevelLocked == 28)
            {
                PL.LoadLevel = 12;
                PL.totalLevelLocked = 27;
                GM.SaveThisGame();
            }
            else if (other.name == "F13" && PL.totalLevelLocked == 27)
            {
                PL.LoadLevel = 13;
                PL.totalLevelLocked = 26;
                GM.SaveThisGame();
            }
            else if (other.name == "F14" && PL.totalLevelLocked == 26)
            {
                PL.LoadLevel = 14;
                PL.totalLevelLocked = 25;
                GM.SaveThisGame();
            }
            else if (other.name == "F15" && PL.totalLevelLocked == 25)
            {
                PL.LoadLevel = 15;
                PL.totalLevelLocked = 24;
                GM.SaveThisGame();
            }
            else if (other.name == "F16" && PL.totalLevelLocked == 24)
            {
                PL.LoadLevel = 16;
                PL.totalLevelLocked = 23;
                GM.SaveThisGame();
            }
            else if (other.name == "F17" && PL.totalLevelLocked == 23)
            {
                PL.LoadLevel = 17;
                PL.totalLevelLocked = 22;
                GM.SaveThisGame();
            }
            else if (other.name == "F18" && PL.totalLevelLocked == 22)
            {
                PL.LoadLevel = 18;
                PL.totalLevelLocked = 21;
                GM.SaveThisGame();
            }
            else if (other.name == "F19" && PL.totalLevelLocked == 21)
            {
                PL.LoadLevel = 19;
                PL.totalLevelLocked = 20;
                GM.SaveThisGame();
            }
            else if (other.name == "F20" && PL.totalLevelLocked == 20)
            {
                PL.LoadLevel = 20;
                PL.totalLevelLocked = 19;
                GM.SaveThisGame();
            }
            else if (other.name == "F21" && PL.totalLevelLocked == 19)
            {
                PL.LoadLevel = 21;
                PL.totalLevelLocked = 18;
                GM.SaveThisGame();
            }
            else if (other.name == "F22" && PL.totalLevelLocked == 18)
            {
                PL.LoadLevel = 22;
                PL.totalLevelLocked = 17;
                GM.SaveThisGame();
            }
            else if (other.name == "F23" && PL.totalLevelLocked == 17)
            {
                PL.LoadLevel = 23;
                PL.totalLevelLocked = 16;
                GM.SaveThisGame();
            }
            else if (other.name == "F24" && PL.totalLevelLocked == 16)
            {
                PL.LoadLevel = 24;
                PL.totalLevelLocked = 15;
                GM.SaveThisGame();
            }
            else if (other.name == "F25" && PL.totalLevelLocked == 15)
            {
                PL.LoadLevel = 25;
                PL.totalLevelLocked = 14;
                GM.SaveThisGame();
            }
            else if (other.name == "F26" && PL.totalLevelLocked == 14)
            {
                PL.LoadLevel = 26;
                PL.totalLevelLocked = 13;
                GM.SaveThisGame();
            }
            else if (other.name == "F27" && PL.totalLevelLocked == 13)
            {
                PL.LoadLevel = 27;
                PL.totalLevelLocked = 12;
                GM.SaveThisGame();
            }
            else if (other.name == "F28" && PL.totalLevelLocked == 12)
            {
                PL.LoadLevel = 28;
                PL.totalLevelLocked = 11;
                GM.SaveThisGame();
            }
            else if (other.name == "F29" && PL.totalLevelLocked == 11)
            {
                PL.LoadLevel = 29;
                PL.totalLevelLocked = 10;
                GM.SaveThisGame();
            }
            else if (other.name == "F30" && PL.totalLevelLocked == 10)
            {
                
            }
            ENV.PlayballFinalReach(other.transform.gameObject);
            other.transform.gameObject.SetActive(false);
            GM.isPlaymode = false;
            GM.StartCoroutine("LoadnextLevel");
        }

    }
}
