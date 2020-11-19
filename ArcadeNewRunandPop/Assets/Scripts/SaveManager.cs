using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public Player _player;

    public void SaveData(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.dat";
        FileStream fstream = new FileStream(path, FileMode.Create);
        GameData gdata = new GameData(player);
        formatter.Serialize(fstream, gdata);
        fstream.Close();
        Debug.Log("The Game will now being saved as general");
    }

    public void SaveFirst()
    {
        string gamepath = Application.persistentDataPath + "/Player.dat";
        FileStream fstream = new FileStream(gamepath, FileMode.Create);
        BinaryFormatter binFor = new BinaryFormatter();
        binFor.Serialize(fstream, _player.mydata);
        fstream.Close();
        Debug.Log("The Game is being saved for the first time");
    }

    public void Load()
    {
        string gamePath = Application.persistentDataPath + "/Player.dat";
        if(File.Exists(gamePath))
        {
            _player.isPathexists = true;
            FileStream fStream = new FileStream(gamePath, FileMode.Open);
            BinaryFormatter binFor = new BinaryFormatter();
            _player.mydata = (GameData)binFor.Deserialize(fStream) as GameData;
            fStream.Close();
        }
        else
        {
            Debug.Log("Here we are buddy, do not worry, we will solve the problem");
            _player.isPathexists = false;
            SaveFirst();
        }
    }

}
