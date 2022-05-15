using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int money;
    public int[] itemsLeft;
    public float[] pos;
    public bool tutorialPlayed;
    public int itemsArraySelected;
    public int itemsArraySelectedPos;
    
    public int[] placePos;
    public int[] placedRot;
    public string[] placedObject;
    public int[] itemSelectedSpw;

    public PlayerData(MoneyManager moneyManager, BuildManager buildManager, camerMovment camerMovment, SetPictures setPictures, PlacedObjectSaverManager placedObjectSaverManager)
    {
        money = moneyManager.money;
        itemsLeft = buildManager.itemsAmount;

        pos = new float[3];
        pos[0] = camerMovment.transform.position.x;
        pos[1] = camerMovment.transform.position.y;
        pos[2] = camerMovment.transform.position.z;

        tutorialPlayed = setPictures.tutorialPlayed;

        itemsArraySelected = buildManager.itemArraySelected;
        itemsArraySelectedPos = buildManager.itemArraySelectedPos;
        placePos = placedObjectSaverManager.placePos;
        placedRot = placedObjectSaverManager.placedRot;
        placedObject = placedObjectSaverManager.placedObject;
        itemSelectedSpw = placedObjectSaverManager.itemSelectedSpw;
    }
}
