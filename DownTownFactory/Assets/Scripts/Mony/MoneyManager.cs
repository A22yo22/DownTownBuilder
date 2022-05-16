using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    //reference to the textobject for the display of the money
    public TMP_Text moneyText;

    //the money amount the player has
    public int money;

    void Start()
    {
        //refreshes the money text
        RefreshMoneyText();
    }
    
    //this function is used to add new money to the money variable
    public void AddMoney(int amount)
    {
        //adds the new money to the money variable
        money += amount;
        //refreshes the money text
        RefreshMoneyText();
    }

    //this function is used to devide money from the money variable
    public void DevedeMoney(int amount)
    {
        //devides the money from the variable
        money -= amount;
        //refresches the money text
        RefreshMoneyText();
    }

    //this function is used to set the money to a sertand value
    public void SetMoney(int amount)
    {
        //sets money to the amount the pleyer wants
        //not the player the other Scripts
        money = amount;
        //refresches the money text
        RefreshMoneyText();
    }

    //used to refresh the money text
    public void RefreshMoneyText()
    {
        //refresches the text
        moneyText.text = money.ToString() + "$";
    }
}
