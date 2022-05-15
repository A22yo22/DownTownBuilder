using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnerObjectSelection : MonoBehaviour
{
    public int itemSeleted;

    public TMP_Text itemSlecetedInMenue;

    public GameObject spawnMenu;

    public GameObject spawnerOBJ;

    void Update()
    {
        if (spawnMenu.activeInHierarchy == true)
        {
            int x = spawnerOBJ.GetComponent<SpawnManagerObject>().itemSeleted;
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
    
    public void SetSpawnerItem()
    {
        spawnerOBJ.GetComponent<SpawnManagerObject>().itemSeleted = itemSeleted;
    }
    
    public void Aluminium()
    {
        itemSeleted = 0;
        itemSlecetedInMenue.text = "Aluminium";
        SetSpawnerItem();
    }
    
    public void Wood()
    {
        itemSeleted = 1;
        itemSlecetedInMenue.text = "Wood";
        SetSpawnerItem();
    }
    
    public void Diamond()
    {
        itemSeleted = 2;
        itemSlecetedInMenue.text = "Diamond";
        SetSpawnerItem();
    }
    
    public void Gold()
    {
        itemSeleted = 3;
        itemSlecetedInMenue.text = "Gold";
        SetSpawnerItem();
    }
    
    public void Iron()
    {
        itemSeleted = 4;
        itemSlecetedInMenue.text = "Iron";
        SetSpawnerItem();
    }
}
