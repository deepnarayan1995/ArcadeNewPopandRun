using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SaveManager SM;
    public Player PL;
    Camera cam;
    public GameObject Ball;
    Vector3 camPos;
    private bool isCamMoving;
    private float camMovespeed = 2f;
    private float camZoomOutspeed = 3.5f;

    public bool isPlaymode;
    public GameObject menuPanel;
    public GameObject gamePanel;
    public Animator menuDisappear;
    public GameObject fakeBall;
    public ParticleSystem round;

    public EnvActivation Env;
    public BallMovement BallMov;
    public CameraMovement camMv;

    [HideInInspector]
    public bool isGameover;

    [HideInInspector]
    public int LoadLevel;//this variable will be saved///

    public GameObject sceneFade;
    public GameObject[] Levels;

    bool isEscapeActive;
    bool isPaused;
    bool isgamestarted;
    public GameObject pausePanel;
    public GameObject SuretoExitPanel;
    bool isDirectLevelOpen;
    public Animator EntryFade;


    void Awake()
    {
        LoadThisGame();
        //Application.targetFrameRate = 60;
        isDirectLevelOpen = PL.isDirectLevelOpeninginGameScene;
        
    }

    void Start()
    {
        if(isDirectLevelOpen)
        {
            LoadLevel = PL.temporaryLoadLevel;
            StartCoroutine("DirectStartLevel");
            Debug.Log(LoadLevel);
        }
        else
        {
            Debug.Log(LoadLevel);
            LoadLevel = PL.LoadLevel;
            isEscapeActive = false;
            isgamestarted = false;
            isPaused = false;
            isGameover = false;
            isCamMoving = false;
            camPos.x = Ball.transform.position.x;
            camPos.y = Ball.transform.position.y;
            camPos.z = -10f;
            cam = Camera.main;
            cam.orthographicSize = 1.5f;
            cam.transform.position = camPos;
            isPlaymode = false;
            Levels[LoadLevel].SetActive(true);
        }
    }

    void Update()
    {
        if(isCamMoving)
        {
            float step = camMovespeed * Time.deltaTime;
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(0f, 0f, -10f), step);
            if(cam.orthographicSize < 5f)
            {
                cam.orthographicSize += camZoomOutspeed * Time.deltaTime;
            }
            if(cam.orthographicSize >= 5f)
            {
                cam.orthographicSize = 5f;
            }
            if(cam.transform.position == new Vector3(0f, 0f, -10f) && cam.orthographicSize == 5f)
            {
                isCamMoving = false;
            }
        }
        if(isEscapeActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
            {
                PauseGame();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
            {
                ResumeGame();
            }
        }
        else if(!isEscapeActive && !isgamestarted)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine("LoadMenuscene");
            }            
        }
    }

    #region GameSaving code

    public void SaveThisGame()
    {
        SM.SaveData(PL);
    }
    public void LoadThisGame()
    {
        SM.Load();
        if(PL.isPathexists)
        {
            PL.LoadLevel = PL.mydata.gdLoadLevel;
            PL.totalLevelLocked = PL.mydata.gdTotalLevelLocked;
            PL.isDirectLevelOpeninginGameScene = PL.mydata.gdisDirectLevelOpening;
            PL.temporaryLoadLevel = PL.mydata.gdtempLoadLev;
        }
    }

    #endregion

    public void StartGame()
    {
        isgamestarted = true;
        StartCoroutine("start_Game");
    }
    IEnumerator start_Game()
    {
        fakeBall.GetComponent<Animator>().SetTrigger("Jarvis");
        menuDisappear.SetTrigger("startGame");
        //yield return new WaitForSeconds(0.5f);
        
        yield return new WaitForSeconds(1.2f);
        round.Play();
        yield return new WaitForSeconds(1.5f);
        menuPanel.SetActive(false);        
        //yield return new WaitForSeconds(1f);
        isCamMoving = true;
        yield return new WaitForSeconds(1.5f);
        isPlaymode = true;
        gamePanel.SetActive(true);
        Env.LevelWays[LoadLevel].SetActive(true);
        Destroy(round.transform.gameObject);
        Destroy(fakeBall.transform.gameObject);
        isEscapeActive = true;        
    }

    IEnumerator DirectStartLevel()
    {
        menuPanel.SetActive(false);
        Destroy(round.transform.gameObject);
        Destroy(fakeBall.transform.gameObject);
        isEscapeActive = false;
        isgamestarted = false;
        isPaused = false;
        isGameover = false;
        isCamMoving = false;
        //camPos.x = Ball.transform.position.x;
        //camPos.y = Ball.transform.position.y;
        //camPos.z = -10f;
        cam = Camera.main;
        cam.orthographicSize = 5f;
        cam.transform.position = new Vector3(0f, 0f, -10f);
        isPlaymode = false;
        Levels[LoadLevel].SetActive(true);

        yield return new WaitForSeconds(1f);

        isgamestarted = true;
        isPlaymode = true;
        gamePanel.SetActive(true);
        Env.LevelWays[LoadLevel].SetActive(true);
        PL.isDirectLevelOpeninginGameScene = false;
        PL.temporaryLoadLevel = 0;
        SaveThisGame();
        isEscapeActive = true;
    }

    IEnumerator LoadMenuscene()
    {
        sceneFade.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene("Menuscene");
    }

    public IEnumerator RestartLevel()
    {        
        sceneFade.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        WayChilds.Instance.ActiveChilds();
        Env.ActiveAllDestinations(LoadLevel);
        camMv.isMoving = false;
        camMv.iscamerareached = false;
        isGameover = false;
        Ball.transform.gameObject.SetActive(true);
        Ball.transform.position = new Vector3(0f, -2f, 0f);
        cam.transform.position = new Vector3(0f, 0f, -10f);
        yield return new WaitForSeconds(0.75f);
        sceneFade.SetActive(false);
        GetDestinations();
        isPlaymode = true;
    }
    public IEnumerator LoadnextLevel()
    {
        yield return new WaitForSeconds(0.75f);        
        sceneFade.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        camMv.isMoving = false;
        camMv.iscamerareached = false;
        Ball.transform.position = new Vector3(0f, -2f, 0f);
        cam.transform.position = new Vector3(0f, 0f, -10f);
        LoadLevel++;
        Levels[LoadLevel - 1].SetActive(false);
        Levels[LoadLevel].SetActive(true);
        yield return new WaitForSeconds(0.75f);
        sceneFade.SetActive(false);
        GetDestinations();
        Env.LevelWays[LoadLevel].SetActive(true);
        isPlaymode = true;
        LoadThisGame();
    }
    private void GetDestinations()
    {
        BallMov.initDest = 0;
        BallMov.totalDest = Env.levelDest[LoadLevel].Length;
        BallMov.target = Env.levelDest[LoadLevel][BallMov.initDest].transform.position;
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void OpenConfirmtoExitaLevel()
    {
        isEscapeActive = false;
        SuretoExitPanel.SetActive(true);
    }
    public void CloseConfirmtoExitaLevel()
    {
        isEscapeActive = true;
        SuretoExitPanel.SetActive(false);
    }
    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine("LoadMenuscene");
    }

}
