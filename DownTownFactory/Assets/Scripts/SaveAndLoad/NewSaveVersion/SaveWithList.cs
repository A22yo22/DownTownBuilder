using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SaveWithList : MonoBehaviour
{
    //reference to some Scripts(needed to get the save data)
    public MoneyManager moneyManager;
    public BuildManager buildManager;
    public camerMovment camerMovment;
    public SetPictures setPictures;

    //Data to save
    //Object possition, 0=x 1=z
    public List<int> placePos;

    //Object Rotation, 0=rot
    public List<int> placeRot;

    //Object Names 0=Name
    public List<string> placedObject;

    //Spawner item selected
    public List<int> spawnerIDForLoading;
    public List<int> itemSelectedSpw;

    //Save and Loade Stuff


    public void SaveGame()
    {
        //Saves the money
        PlayerPrefs.SetInt("money", moneyManager.money);

        //Saves the Items left list
        PlayerPrefs.SetInt("itemsLeftLength", buildManager.itemsAmount.Count);

        for (int i = 0; i < buildManager.itemsAmount.Count; i++)
        {
            PlayerPrefs.SetInt("itemsLeft" + i, buildManager.itemsAmount[i]);
        }

        //Saves the playerPos
        PlayerPrefs.SetFloat("x", camerMovment.transform.position.x);
        PlayerPrefs.SetFloat("y", camerMovment.transform.position.y);
        PlayerPrefs.SetFloat("z", camerMovment.transform.position.z);

        //Saves the tutorial played bool
        PlayerPrefs.SetInt("tutorialPlayed", boolToInt(setPictures.tutorialPlayed));




        //Saves the length of the objects so the load function can run the loop
        PlayerPrefs.SetInt("placePosLength", placePos.Count);
        PlayerPrefs.SetInt("placeRotLength", placeRot.Count);
        PlayerPrefs.SetInt("spawnerIDLength", spawnerIDForLoading.Count);

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
        }

        //needs a single one because the rot is added even when the spawner isn´t played
        for(int i = 0; i < spawnerIDForLoading.Count; i++)
        {
            PlayerPrefs.SetInt("spawnerIDForLoading" + i, spawnerIDForLoading[i]);
            PlayerPrefs.SetInt("itemSelectedSpw" + i, itemSelectedSpw[i]);
        }
    }

    //Loads the game
    public void LoadGame()
    {
        //Loads the money
        moneyManager.money = PlayerPrefs.GetInt("money");

        //Loads Items left
        int itemsLeftLength = PlayerPrefs.GetInt("itemsLeftLength");

        for (int i = 0; i < itemsLeftLength; i++)
        {
            buildManager.itemsAmount.Add(PlayerPrefs.GetInt("itemsLeft" + i));
        }

        //Loads Player possition
        Vector3 pos = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
        camerMovment.transform.position = pos;

        //Loads the tutorial played bool
        setPictures.tutorialPlayed = intToBool(PlayerPrefs.GetInt("tutorialPlayed"));



        int posListLength = PlayerPrefs.GetInt("placePosLength");
        int rotListLength = PlayerPrefs.GetInt("placeRotLength");
        int spawnerIDLength = PlayerPrefs.GetInt("spawnerIDLength");

        for(int i = 0; i < posListLength; i++)
        {
            placePos.Add(PlayerPrefs.GetInt("placePos" + i));
        }

        for (int i = 0; i < rotListLength; i++)
        {
            placeRot.Add(PlayerPrefs.GetInt("placeRot" + i));
            placedObject.Add(PlayerPrefs.GetString("placedObject" + i));
        }

        for(int i = 0; i < spawnerIDLength; i++)
        {
            itemSelectedSpw.Add(PlayerPrefs.GetInt("spawnerIDForLoading" + i));
            itemSelectedSpw.Add(PlayerPrefs.GetInt("itemSelectedSpw" + i));
        }
    }

    //sorts out spawner ID´s so they can be spawned corecktly
    public void SpawnerIDSorter()
    {
        for(int i = 1; i < spawnerIDForLoading.Count; i++)
        {
            //saves spawner id for chenking in a sec
            int spawnerID = spawnerIDForLoading[i];
            bool pased = false;

            for(int i2 = 0; i < spawnerIDForLoading.Count; i++)
            {
                if (pased)
                {
                    if(spawnerID == spawnerIDForLoading[i2])
                    {
                        Debug.Log(spawnerIDForLoading[i]);
                        Debug.Log(itemSelectedSpw[i]);
                        spawnerIDForLoading.RemoveAt(spawnerID);
                        itemSelectedSpw.RemoveAt(spawnerID);
                    }
                }

                pased = true;
            }
        }
    }

    //Sets the spawner id and the item selected
    public void SetSpawnerIDAndItemSelected(int spawnerID, int itemSelected)
    {
        spawnerIDForLoading.Add(spawnerID);
        itemSelectedSpw.Add(itemSelected);
        SpawnerIDSorter();
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
