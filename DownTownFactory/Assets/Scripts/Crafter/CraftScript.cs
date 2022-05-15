using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class CraftScript : MonoBehaviour
{
    [Header("0 = Aluminium, 1 = Wood, 2 = Diamond, 3 = Gold, 4 = Iron, 5 = Stick, 6 = Head, 7 = axt, 8 = Circuit Board")]
    [Header("9 = CPU")]
    public int[] items;
    //0 = stick, 1 = head, 2 = axt, 3 = platine
    public GameObject[] spawnItems;

    //Possition to spawn Crafted Objects
    public Transform spwanPos;
    
    [Header("0 = aluminium, 1 = wood, 2 diamond, 3 = gold, 4 = iron, 5 = stick, 6 = head, 7 = axt, 8 = Circuit Board")]
    [Header("9 = CPU")]
    public TMP_Text[] crafterItemsAmount;
    
    //used to test what item enters(the name of it)
    public string[] tagNames;
    //used to see wich items you need to craft somthing
    public string[] craftNames;
    
    //the craftmode Selected by the craftStettings
    public string craftMode;

    //item object with the craft information on them
    [Header("0 = stick, 1 = head, 2 = axt, 3 = Circuit Board, 4 = CPU")]
    public Items[] itemData;

    //audioSource
    public AudioSource audioLister;
    
    [Header("Item Options")]
    //items in crafter
    public int[] placeItem;

    //items needed to craft thomthing
    public int[] itemsNeeded;

    //items to spawn
    public int spawnItemNumber;

    //the time an item needs to spawn
    public int timeToWait;
    
    private void OnTriggerEnter(Collider other)
    {
        //test the item that enter who it is and adds ist to the item list
        for (int i = 0; i < tagNames.Length; i++)
        {
            if (other.GetComponent<Worth>().tagName == tagNames[i])
            {
                items[i] += other.gameObject.GetComponent<Worth>().anzahl;
                Destroy(other.gameObject);
            }
        }
    }

    //sets the items display for the items in the spawner
    public void SetItemAnzeiger(TMP_Text[] itemAmounts)
    {
        crafterItemsAmount = itemAmounts;
    }

    public void StartCrafting()
    {
        //gets the materials needed to craft thomthing
        for (int i = 0; i < craftNames.Length; i++)
        {
            if (craftMode == craftNames[i])
            {
                placeItem = itemData[i].placeItem;
                itemsNeeded = itemData[i].itemsNeeded;
                spawnItemNumber = itemData[i].spawnItemNumber;
                timeToWait = itemData[i].timeToWait;
            }
        }

        StartCoroutine(Craft(craftMode, timeToWait));
    }

    //sets the text for the items diplay 
    public void SetItemsPickedp()
    {
        for (int i = 0; i < crafterItemsAmount.Length; i++)
        {
            crafterItemsAmount[i].text = items[i].ToString();
        }
    }

    //craft the object
    public IEnumerator Craft(string thing, int time)
    {
        askThing(thing, placeItem, itemsNeeded, spawnItemNumber);
        yield return new WaitForSeconds(time);
        StartCoroutine(Craft(craftMode, timeToWait));
    }

    //subtracs the items when thomthing is crafted
    public void askThing(string thing, int[] placeItem, int[] itemsNeeded, int spawnItemNumber)
    {
        for (int i = 0; i < craftNames.Length; i++)
        {
            if (thing == craftNames[i])
            {
                if (items[placeItem[0]] >= itemsNeeded[0] && items[placeItem[1]] >= itemsNeeded[1] && items[placeItem[2]] >= itemsNeeded[2])
                {
                    items[placeItem[0]] -= itemsNeeded[0];
                    items[placeItem[1]] -= itemsNeeded[1];
                    items[placeItem[2]] -= itemsNeeded[2];
                    WaitThanSpawn(spawnItems[spawnItemNumber]);
                }
            }
        }
    }
    
    private void WaitThanSpawn(GameObject spawnOBJ)
    {
        audioLister.Play();
        spawnOBJ = Instantiate(spawnOBJ);
        spawnOBJ.transform.position = spwanPos.position;
        switch (transform.rotation.y)
        {
            //0
            case 0f:
                spawnOBJ.GetComponent<Rigidbody>().AddForce(Vector3.right * 6f, ForceMode.Impulse);
                break;
            //90
            case 0.7071068f:
                spawnOBJ.GetComponent<Rigidbody>().AddForce(Vector3.back * 6f, ForceMode.Impulse);
                break;
            //-90
            case -0.7071068f:
                spawnOBJ.GetComponent<Rigidbody>().AddForce(Vector3.forward * 6f, ForceMode.Impulse);
                break;
            //180
            case 1:
                spawnOBJ.GetComponent<Rigidbody>().AddForce(Vector3.left * 6f, ForceMode.Impulse);
                break;
            //-180
            case -1:
                spawnOBJ.GetComponent<Rigidbody>().AddForce(Vector3.left * 6f, ForceMode.Impulse);
                break;
        }
    }
}
