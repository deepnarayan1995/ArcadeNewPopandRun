using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Game Saving variables
    [HideInInspector]
    public int isAdRemoved;

    [HideInInspector]
    public int LoadLevel = 0;

    [HideInInspector]
    public int totalLevelLocked = 39;

    [HideInInspector]
    public bool isDirectLevelOpeninginGameScene;

    [HideInInspector]
    public int temporaryLoadLevel;

    #endregion

    [HideInInspector]
    public GameData mydata;
    [HideInInspector]
    public bool isPathexists;

}
