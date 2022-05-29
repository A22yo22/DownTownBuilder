using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellScipt : MonoBehaviour
{
    //reference to moneyManager
    public MoneyManager moneymanagerScript;

    void Start()
    {
        //gets money manager
        moneymanagerScript = FindObjectOfType<MoneyManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sells item");

        //gets the item thats going to get saild
        int x = other.GetComponent<Worth>().worth;
        //adds the items worth to money
        moneymanagerScript.AddMoney(x);
        
        //destroys the item entered
        Destroy(other.gameObject);
    }
}
