using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //money
    public int money;

    //items that the player have left in his Inventory
    public int[] itemsLeft;

    //Camera position / Player position
    public float[] pos;

    //true if player wached the tutorial
    public bool tutorialPlayed;

    //used to Select item in arrys like rot and names array in the BuildManager
    public int itemsArraySelected;

    //also used Select places in arrays from the buildManager like the possition array
    public int itemsArraySelectedPos;
    
    //all positions of the objects spawned, 0=x 1=z
    public int[] placePos;

    //rotation of the objects
    public int[] placedRot;

    //names of the object to spawn the right one
    public string[] placedObject;

    //items selected to spawn
    public int[] itemSelectedSpw;

    //Class to save the date in the objects
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
