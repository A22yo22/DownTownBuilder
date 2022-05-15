using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts;

public static class SaveSystem
{
    //Save function
    public static void SavePlayer(MoneyManager moneyManager, BuildManager buildManager, camerMovment camerMovment, SetPictures setPictures, PlacedObjectSaverManager placedObjectSaverManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.bobs";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(moneyManager, buildManager, camerMovment, setPictures, placedObjectSaverManager);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //load function
    public static PlayerData loadPlayer()
    {
        string path = Application.persistentDataPath + "/player.bobs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stram = new FileStream(path, FileMode.Open);
            
            PlayerData data = formatter.Deserialize(stram) as PlayerData;
            stram.Close();
            
            Debug.Log(path);
            
            return data;
        }
        else
        {
            return null;
        }
    }
}
