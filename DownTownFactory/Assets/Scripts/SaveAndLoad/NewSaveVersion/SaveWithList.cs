using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveWithList : MonoBehaviour
{
    //Data to save
    //Object possition, 0=x 1=z
    public List<int> placePos;

    //Object Rotation, 0=rot
    public List<int> placeRot;

    //Object Names 0=Name
    public List<string> placedObject;

    //Spawner item selected
    public List<int> itemSelectedSpw;



    //Save and Loade Stuff


    public void SaveGame()
    {
        //Saves the length of the objects so the load function can run the loop
        PlayerPrefs.SetInt("placePosLength", placePos.Count);
        PlayerPrefs.SetInt("placeRotLength", placeRot.Count);

        //Saves the Lists
        //Can´t be used because the placePos has two times as much plces as the other lists
        for(int i = 0; i < placePos.Count; i++)
        {
            PlayerPrefs.SetInt("placePos" + i, placePos[i]);
        }

        //here all objects can be used because they all have the same length
        for (int i = 0; i < placeRot.Count; i++)
        {
            PlayerPrefs.SetInt("placeRot" + i, placeRot[i]);
            PlayerPrefs.SetString("placedObject" + i, placedObject[i]);
            PlayerPrefs.SetInt("itemSelectedSpw" + i, itemSelectedSpw[i]);
        }
    }

    //Loads the game
    public void LoadGame()
    {
        Debug.Log("Loded");
        int posListLength = PlayerPrefs.GetInt("placePosLength");
        int rotListLength = PlayerPrefs.GetInt("placeRotLength");

        for(int i = 0; i < posListLength; i++)
        {
            placePos.Add(PlayerPrefs.GetInt("placePos" + i));
        }

        for (int i = 0; i < rotListLength; i++)
        {
            placeRot.Add(PlayerPrefs.GetInt("placeRot" + i));
            placedObject.Add(PlayerPrefs.GetString("placedObject" + i));
            itemSelectedSpw.Add(PlayerPrefs.GetInt("itemSelectedSpw" + i));
        }
    }
}
