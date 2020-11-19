using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public SaveManager SM;
    public Player PL;

    public GameObject[] ActivImages;
    public GameObject[] LockImages;
    public GameObject[] LevelNumerics;
    bool[] isLevelActive = new bool[40];
    int totalLocked;
    private bool isEscapeActive;
    private bool isExitpanelActive;
    public GameObject ExitPanel;

    public Animator fadeScene;
    public GameObject UnlockPrevLvl;


    void Awake()
    {
        LoadThisGame();
        StartCoroutine("ActiveEscape");
        for(int i = 0; i < ActivImages.Length; i++)
        {
            ActivImages[i].SetActive(false);
        }
    }

    void Start()
    {
        totalLocked = PL.totalLevelLocked;
        //totalLocked = 39;
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


    void Update()
    {
        if(isEscapeActive)
        {
            if(Input.GetKeyDown(KeyCode.Escape) && !isExitpanelActive)
            {
                isExitpanelActive = true;
                ExitPanel.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.Escape) && isExitpanelActive)
            {
                isExitpanelActive = false;
                ExitPanel.SetActive(false);
            }
        }
    }


    public void SaveThisGame()
    {
        SM.SaveData(PL);
    }
    public void LoadThisGame()
    {
        SM.Load();
        if (PL.isPathexists)
        {
            PL.LoadLevel = PL.mydata.gdLoadLevel;
            PL.totalLevelLocked = PL.mydata.gdTotalLevelLocked;
            PL.isDirectLevelOpeninginGameScene = PL.mydata.gdisDirectLevelOpening;
            PL.temporaryLoadLevel = PL.mydata.gdtempLoadLev;
        }
    }

    public void LoadGameLevel(int levelNumber)
    {
        if(isLevelActive[levelNumber - 1])
        {
            PL.temporaryLoadLevel = levelNumber - 1;
            PL.isDirectLevelOpeninginGameScene = true;
            SaveThisGame();
            StartCoroutine("LoadLevelWait");
        }
        else
        {
            StartCoroutine("UnlockPrev");
        }
    }

    IEnumerator LoadLevelWait()
    {
        fadeScene.SetTrigger("FadeOut");
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator UnlockPrev()
    {
        isEscapeActive = false;
        UnlockPrevLvl.SetActive(true);
        yield return new WaitForSeconds(2f);
        UnlockPrevLvl.SetActive(false);
        isEscapeActive = true;
    }
    IEnumerator ActiveEscape()
    {
        yield return new WaitForSeconds(1f);
        isEscapeActive = true;
    }
    public void CloseExit()
    {
        isExitpanelActive = false;
        ExitPanel.SetActive(false);
    }
    public void ExitApp()
    {
        Application.Quit();
    }

}
