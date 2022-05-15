using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SaveAndLoadManager : MonoBehaviour
{
    public MoneyManager moneyManager;
    public BuildManager buildManager;
    public camerMovment camerMovment;
    public SetPictures setPictures;
    public PlacedObjectSaverManager placedObjectSaverManager;

    [Header("0 = Förderband, 1 = Spawner, 2 = Seller, 3 = Crafter")]
    public GameObject[] objects;
    
    public void Save()
    {
        SaveSystem.SavePlayer(moneyManager, buildManager, camerMovment, setPictures, placedObjectSaverManager);
    }

    public void Load()
    {
        PlayerData data = SaveSystem.loadPlayer();
        
        moneyManager.SetMoney(data.money);
        buildManager.itemsAmount = data.itemsLeft;
        camerMovment.transform.position = new Vector3(data.pos[0], data.pos[1], data.pos[2]);
        setPictures.tutorialPlayed = data.tutorialPlayed;

        buildManager.itemArraySelected = data.itemsArraySelected;
        buildManager.itemArraySelectedPos = data.itemsArraySelectedPos;
        placedObjectSaverManager.placePos = data.placePos;
        placedObjectSaverManager.placedRot = data.placedRot;
        placedObjectSaverManager.placedObject = data.placedObject;
        placedObjectSaverManager.itemSelectedSpw = data.itemSelectedSpw;

        spawnObjects(data.placePos, data.placedRot, data.placedObject, data.itemSelectedSpw);
    }

    public void spawnObjects(int[] placePos, int[] placeRot, string[] placedObject, int[] itemSelectedSpw)
    {
        int x = 0;
        int rot = 0;

        for (int i = 0; i < placePos.Length; i += 2)
        {
            int z = placePos[i];
            int y = placePos[i + 1];

            bool pased = false;
            for (int i2 = 0; i2 < placePos.Length; i2 += 2)
            {
                if (z == placePos[i2])
                {
                    if (y == placePos[i2 + 1])
                    {
                        if (pased)
                        {
                            placePos[i] = 0;
                            placePos[i + 1] = 0;
                            placeRot[i/2] = 0;
                            placedObject[i/2] = null;
                        }

                        pased = true;
                    }
                }
            }
        }

        for (int i = 0; i < placePos.Length - 2; i += 2)
        {
            if (placePos[i] == 0)
            {
                rot++;
                x++;
            }

            if (Physics.Raycast(new Vector3(placePos[i], 1, placePos[i + 1]), -Vector3.up, out RaycastHit hit, Mathf.Infinity, 6))
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
