using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerObjectSelection : MonoBehaviour
{
    //reference to the SaveWithList Script
    public SaveWithList saveWithList;

    //the selected object in the spawner
    public int itemSeleted;

    //text in the spawner that shows witch item is slected
    public TMP_Text itemSlecetedInMenue;

    //spawner UI reference
    public GameObject spawnMenu;

    //the spawner that is selected right now
    public GameObject spawnerOBJ;

    void Update()
    {
        //if the spawner is active
        if (spawnMenu.activeInHierarchy == true)
        {
            //gets the item selected to spawn from the spawnerOBJ
            int x = spawnerOBJ.GetComponent<SpawnManagerObject>().itemSeleted;
            //sets the text in the spawner to show wich
            //item is selected depending on the input it gets from x
            if (x == 0)
            {
                itemSlecetedInMenue.text = "Aluminium";
            }
            else if (x == 1)
            {
                itemSlecetedInMenue.text = "Wood";
            }
            else if (x == 2)
            {
                itemSlecetedInMenue.text = "Diamond";
            }
            else if (x == 3)
            {
                itemSlecetedInMenue.text = "Gold";
            }
            else if (x == 4)
            {
                itemSlecetedInMenue.text = "Iron";
            }
        }
    }

    //sorts out spawner ID´s so they can be spawned corecktly
    public void SpawnerIDSorter()
    {

    }

    //sets the item that the player has selected in the menue
    public void SetSpawnerItem()
    {
        spawnerOBJ.GetComponent<SpawnManagerObject>().itemSeleted = itemSeleted;
    }
    
    //sets the item to spawn to aluminium
    public void Aluminium()
    {
        itemSeleted = 0;
        itemSlecetedInMenue.text = "Aluminium";
        SetSpawnerItem();
        saveWithList.SetSpawnerIDAndItemSelected(spawnerOBJ.GetComponent<SpawnManagerObject>().spawnerID, itemSeleted);
    }
    
    //sets the item to spawn to Wood
    public void Wood()
    {
        itemSeleted = 1;
        itemSlecetedInMenue.text = "Wood";
        SetSpawnerItem();
        saveWithList.SetSpawnerIDAndItemSelected(spawnerOBJ.GetComponent<SpawnManagerObject>().spawnerID, itemSeleted);
    }
    
    //sets the item to spawn to Diamond
    public void Diamond()
    {
        itemSeleted = 2;
        itemSlecetedInMenue.text = "Diamond";
        SetSpawnerItem();
        saveWithList.SetSpawnerIDAndItemSelected(spawnerOBJ.GetComponent<SpawnManagerObject>().spawnerID, itemSeleted);
    }
    
    //sets the item to spawn to Gold
    public void Gold()
    {
        itemSeleted = 3;
        itemSlecetedInMenue.text = "Gold";
        SetSpawnerItem();
        saveWithList.SetSpawnerIDAndItemSelected(spawnerOBJ.GetComponent<SpawnManagerObject>().spawnerID, itemSeleted);
    }
    
    //sets the item to spawn to Iron
    public void Iron()
    {
        itemSeleted = 4;
        itemSlecetedInMenue.text = "Iron";
        SetSpawnerItem();
        saveWithList.SetSpawnerIDAndItemSelected(spawnerOBJ.GetComponent<SpawnManagerObject>().spawnerID, itemSeleted);
    }
}
