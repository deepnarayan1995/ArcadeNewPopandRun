using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    #region All gameplay saving Data

    public int gdLoadLevel;

    public int gdTotalLevelLocked;

    public int gdisAdRemoved;

    public bool gdisMusicOn;

    public bool gdisDirectLevelOpening;

    public int gdtempLoadLev;

    #endregion

    public GameData(Player player)
    {
        gdLoadLevel = player.LoadLevel;
        gdTotalLevelLocked = player.totalLevelLocked;
        gdisDirectLevelOpening = player.isDirectLevelOpeninginGameScene;
        gdtempLoadLev = player.temporaryLoadLevel;
        //gdisAdRemoved = player.isAdRemoved;
    }

}
