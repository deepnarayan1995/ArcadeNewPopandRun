using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //public GameObject[] destination;

    public GameManager GM;
    public EnvActivation Env;

    private float speed = 10f;
    [HideInInspector]
    public Vector3 target;
    [HideInInspector]
    public int totalDest;
    [HideInInspector]
    public int initDest;
    [HideInInspector]
    public bool ismoving;

    void Start()
    {
        initDest = 0;
        totalDest = Env.levelDest[GM.LoadLevel].Length;
        //totalDest = Env.Lev1Dest.Length;
        target = Env.levelDest[GM.LoadLevel][initDest].transform.position;
        //target = Env.Lev1Dest[initDest].transform.position;
        //target = destination[initDest].transform.position;
    }

    public void TapButton()
    {
        if(GM.isPlaymode)
        {
            ismoving = true;
        }
    }

    void Update()
    {
        if(ismoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            if(transform.position == target)
            {
                initDest++;
                ismoving = false;
                if(initDest < totalDest)
                {
                    target = Env.levelDest[GM.LoadLevel][initDest].transform.position;
                }                
            }            
        }
    }

}
