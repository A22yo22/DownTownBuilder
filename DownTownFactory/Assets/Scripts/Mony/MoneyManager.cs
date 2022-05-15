using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public int money;

    void Start()
    {
        moneyText.text = money.ToString() + "$";
    }
    
    public void AddMoney(int amount)
    {
        money += amount;
        moneyText.text = money.ToString() + "$";
    }

    public void DevedeMoney(int amount)
    {
        money -= amount;
        moneyText.text = money.ToString() + "$";
    }

    public void SetMoney(int amount)
    {
        money = amount;
        moneyText.text = money.ToString() + "$";
    }
}
