using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvActivation : MonoBehaviour
{
    public GameObject Ball;

    public GameObject Ballblast;
    public GameObject Ballreachpoint;
    public GameObject BallfinalReach;
    GameObject expl1;
    GameObject expl2;
    GameObject expl3;

    public GameObject[] LevelWays;

    public GameObject[] Lev1Dest, Lev2Dest, Lev3Dest, Lev4Dest, Lev5Dest, Lev6Dest, Lev7Dest, Lev8Dest, Lev9Dest, Lev10Dest;

    public GameObject[] Lev11Dest, Lev12Dest, Lev13Dest, Lev14Dest, Lev15Dest, Lev16Dest, Lev17Dest, Lev18Dest, Lev19Dest, Lev20Dest;

    public GameObject[] Lev21Dest, Lev22Dest, Lev23Dest, Lev24Dest, Lev25Dest, Lev26Dest, Lev27Dest, Lev28Dest, Lev29Dest, Lev30Dest;

    public GameObject[][] levelDest = new GameObject[30][];


    void Awake()
    {
        levelDest[0] = Lev1Dest;
        levelDest[1] = Lev2Dest;
        levelDest[2] = Lev3Dest;
        levelDest[3] = Lev4Dest;
        levelDest[4] = Lev5Dest;
        levelDest[5] = Lev6Dest;
        levelDest[6] = Lev7Dest;
        levelDest[7] = Lev8Dest;
        levelDest[8] = Lev9Dest;
        levelDest[9] = Lev10Dest;
        levelDest[10] = Lev11Dest;
        levelDest[11] = Lev12Dest;
        levelDest[12] = Lev13Dest;
        levelDest[13] = Lev14Dest;
        levelDest[14] = Lev15Dest;
        levelDest[15] = Lev16Dest;
        levelDest[16] = Lev17Dest;
        levelDest[17] = Lev18Dest;
        levelDest[18] = Lev19Dest;
        levelDest[19] = Lev20Dest;
        levelDest[20] = Lev21Dest;
        levelDest[21] = Lev22Dest;
        levelDest[22] = Lev23Dest;
        levelDest[23] = Lev24Dest;
        levelDest[24] = Lev25Dest;
        levelDest[25] = Lev26Dest;
        levelDest[26] = Lev27Dest;
        levelDest[27] = Lev28Dest;
        levelDest[28] = Lev29Dest;
        levelDest[29] = Lev30Dest;
    }

    public void ActiveAllDestinations(int levelno)
    {
        int len = levelDest[levelno].Length;
        for(int i = 0; i < len; i++)
        {
            levelDest[levelno][i].transform.gameObject.SetActive(true);
        }
    }


    public IEnumerator PlayballBlast()
    {
        expl1 = Instantiate(Ballblast) as GameObject;
        expl1.transform.position = Ball.transform.position;
        yield return new WaitForSeconds(1f);
        if(expl1 != null)
        {
            Destroy(expl1.transform.gameObject);
        }        
    }

    public void PlayballReachPoint(GameObject obj)
    {
        StartCoroutine(ballReachPoint(obj));
    }
    IEnumerator ballReachPoint(GameObject obj)
    {
        expl2 = Instantiate(Ballreachpoint) as GameObject;
        expl2.transform.position = obj.transform.position;
        yield return new WaitForSeconds(0.5f);
        if(expl2 != null)
        {
            Destroy(expl2.transform.gameObject);
        }        
    }



    public void PlayballFinalReach(GameObject obj)
    {
        StartCoroutine(ballFinalReach(obj));
    }
    public IEnumerator ballFinalReach(GameObject obj)
    {
        expl3 = Instantiate(BallfinalReach) as GameObject;
        expl3.transform.position = obj.transform.position;
        yield return new WaitForSeconds(1f);
        if (expl3 != null)
        {
            Destroy(expl3.transform.gameObject);
        }
    }

}
