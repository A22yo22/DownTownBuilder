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
    public Transform spwanPos;
    
    [Header("0 = aluminium, 1 = wood, 2 diamond, 3 = gold, 4 = iron, 5 = stick, 6 = head, 7 = axt, 8 = Circuit Board")]
    [Header("9 = CPU")]
    public TMP_Text[] crafterItemsAmount;
    
    public string[] tagNames;
    public string[] craftNames;
    
    public string craftMode;

    [Header("0 = stick, 1 = head, 2 = axt, 3 = Circuit Board, 4 = CPU")]
    public Items[] itemData;

    public AudioSource audioLister;
    
    [Header("Item Options")]
    public int[] placeItem;
    public int[] itemsNeeded;
    public int spawnItemNumber;
    public int timeToWait;
    
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < tagNames.Length; i++)
        {
            if (other.GetComponent<Worth>().tagName == tagNames[i])
            {
                items[i] += other.gameObject.GetComponent<Worth>().anzahl;
                Destroy(other.gameObject);
            }
        }
    }

    public void SetItemAnzeiger(TMP_Text[] itemAmounts)
    {
        crafterItemsAmount = itemAmounts;
    }

    public void StartCrafting()
    {
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

    public void SetItemsPickedp()
    {
        for (int i = 0; i < crafterItemsAmount.Length; i++)
        {
            crafterItemsAmount[i].text = items[i].ToString();
        }
    }

    public IEnumerator Craft(string thing, int time)
    {
        askThing(thing, placeItem, itemsNeeded, spawnItemNumber);
        yield return new WaitForSeconds(time);
        /*if (thing == "stick")
        {
            if (items[1] >= 2)
            {
                items[1] -= 2;
                yield return new WaitForSeconds(1);
                WaitThanSpawn(spawnItems[0]);
            }
        }*/
        StartCoroutine(Craft(craftMode, timeToWait));
    }

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
