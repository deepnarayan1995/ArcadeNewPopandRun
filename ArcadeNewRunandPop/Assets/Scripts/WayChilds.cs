using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayChilds : MonoBehaviour
{
    public static WayChilds Instance;

    public GameObject[] parents;
    private int len;

    void Awake()
    {
        len = parents.Length;
        Instance = this;
    }


    public void ActiveChilds()
    {
        for(int i = 0; i < len; i++)
        {
            for(int j =0; j <= 6; j++)
            {
                parents[i].transform.GetChild(j).gameObject.SetActive(true);
            }
        }        
    }

}
