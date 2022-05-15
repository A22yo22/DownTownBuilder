using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellScipt : MonoBehaviour
{
    public MoneyManager moneymanagerScript;

    void Start()
    {
        moneymanagerScript = FindObjectOfType<MoneyManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        int x = other.GetComponent<Worth>().worth;
        moneymanagerScript.AddMoney(x);
        
        Destroy(other.gameObject);
    }
}
