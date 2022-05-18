using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    //get´s the script reveraces
    public MoneyManager moneyManager;
    public BuildManager buildManager;
    public camerMovment camerMovment;
    public SetPictures setPictures;
    public SaveWithList SaveWithList;

    [Header("0 = Förderband, 1 = Spawner, 2 = Seller, 3 = Crafter")]
    public GameObject[] objects;
    
    //Saves
    public void Save()
    {
        SaveWithList.SaveGame();
        //SaveSystem.SavePlayer(moneyManager, buildManager, camerMovment, setPictures);
    }

    //Load´s the data
    public void Load()
    {
        SaveWithList.LoadGame();
        //Creats a new PlayerData object
        //PlayerData data = SaveSystem.loadPlayer();
        
        //here the saved data of the player gets loaded in the right variables of script plcedObjectSaverManaer
        /*moneyManager.SetMoney(data.money);
        buildManager.itemsAmount = data.itemsLeft;
        camerMovment.transform.position = new Vector3(data.pos[0], data.pos[1], data.pos[2]);
        setPictures.tutorialPlayed = data.tutorialPlayed;

        buildManager.itemArraySelected = data.itemsArraySelected;
        buildManager.itemArraySelectedPos = data.itemsArraySelectedPos;

        //loads the pos, rot, names and Selected items of the player in the variables of script plcedObjectSaverManaer
        placedObjectSaverManager.placePos = data.placePos;
        placedObjectSaverManager.placedRot = data.placedRot;
        placedObjectSaverManager.placedObject = data.placedObject;
        placedObjectSaverManager.itemSelectedSpw = data.itemSelectedSpw;
        */

        //spawns the mashines
        spawnObjects(SaveWithList.placePos, SaveWithList.placeRot, SaveWithList.placedObject, SaveWithList.itemSelectedSpw);
    }

    //this function spawns the mashines with the right data in them as they were when saved
    public void spawnObjects(List<int> placePos, List<int> placeRot, List<string> placedObject, List<int> itemSelectedSpw)
    {
        int x = 0;
        int rot = 0;

        for (int i = 2; i < placePos.Count+2; i += 2)
        {
            //saves the variables if they are the same to chabge them
            int z = placePos[i-2];
            int y = placePos[i - 1];

            //when the array sorter starts the first number gets compared with themselfs so if they
            //are the first time true nothing happens but if its true the second time true 
            //passed is set to true
            bool pased = false;

            //if i2 smaler then plcePoses length i2 plus 2
            for (int i2 = 2; i2 < placePos.Count+2; i2 += 2)
            {
                //if z and y the same placePos 0 and 1(wich can´t happen because they can´t be on the
                //same possition) the first possition gets set to 0 wich is equals null because the first
                //possition on the grid is 15,5
                if (z == placePos[i2-2])
                {
                    if (y == placePos[i2 - 1])
                    {
                        //if passed is true
                        if (pased)
                        {
                            //set placePos 0 and 1 to 0/null
                            SaveWithList.placePos.RemoveAt(i-2);
                            SaveWithList.placePos.RemoveAt(i-2);
                            Debug.Log(i - 2);

                            //the same to the rotation and divided by 2 because i is every loop plus 2
                            //and divided by 2 is the right arry point
                            SaveWithList.placeRot.RemoveAt(i / 2);
                            Debug.Log(i / 2);

                            //the name is also set to null
                            SaveWithList.placedObject.RemoveAt(i / 2);
                        }

                        //passed once so passed is true as described above
                        pased = true;
                    }
                }
            }
        }

        for (int i = 2; i < placePos.Count+2; i += 2)
        {
            //if placePos is zero skip to the next rotation and name
            if (placePos[i-2] == 0)
            {
                rot++;
                x++;
            }

            //spawn next mashine
            if (Physics.Raycast(new Vector3(placePos[i-2], 1, placePos[i - 1]), -Vector3.up, out RaycastHit hit, Mathf.Infinity, 6))
            {
                if (placedObject[x] == "Spawner")
                {
                    hit.collider.gameObject.GetComponent<Manger>().BuildManager(objects[1], placeRot[rot], "Spawner", itemSelectedSpw[x], buildManager.spawnerID);
                    buildManager.spawnerID++;
                }
                else if (placedObject[x] == "Förderband")
                {
                    hit.collider.gameObject.GetComponent<Manger>().BuildManager(objects[0], placeRot[rot]);
                }
                else if (placedObject[x] == "Seller")
                {
                    hit.collider.gameObject.GetComponent<Manger>().BuildManager(objects[2], placeRot[rot]);
                }
                else if (placedObject[x] == "Crafter")
                {
                    hit.collider.gameObject.GetComponent<Manger>().BuildManager(objects[3], placeRot[rot], "Crafter");
                }

                x++;
                rot++;
            }
        }
    }
}
