using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject[] ActivImages;
    public GameObject[] LockImages;
    public GameObject[] LevelNumerics;
    bool[] isLevelActive = new bool[40];
    int totalLocked;
    private bool isEscapeActive;


    void Awake()
    {
        for(int i = 0; i < ActivImages.Length; i++)
        {
            ActivImages[i].SetActive(false);
        }
    }

    void Start()
    {
        totalLocked = 39;
        for (int i = 0; i < 40; i++)
        {
            isLevelActive[i] = true;
        }
        for (int i = 0; i < 39; i++)
        {
            LockImages[i].SetActive(false);
            LevelNumerics[i].SetActive(true);
        }

        for (int i = 1; i <= totalLocked; i++)
        {
            isLevelActive[40 - i] = false;
            LockImages[39 - i].SetActive(true);
            //LevelNumerics[39 - i].SetActive(false);
        }

        ActivImages[39 - totalLocked].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
