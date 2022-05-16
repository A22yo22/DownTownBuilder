using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rezepte : MonoBehaviour
{
    //referanence to some Scripts
    public MoneyManager moneyManager;

    //referances to the craft buttons
    [Header("0 = AxtStick, 1 = AxtHead, 2 = Axt, 3 = Platine")]
    public GameObject[] craftButtons;

    //collection of recipes buttons in the crafafter
    public GameObject[] craftButtonsItems;

    //thes are the buttons to buy the recipes
    public GameObject[] buyButtons;

    //buy AxtStick recipes
    public void AxtStick()
    {
        //if money is higher than 100
        if (moneyManager.money >= 100)
        {
            //devede 100 frome the money
            moneyManager.DevedeMoney(100);
            //set the button in the spawner to true
            craftButtons[0].SetActive(true);
            //set the item the spawner can pickup now to true in the crafter
            craftButtonsItems[0].SetActive(true);
            //disable the buy butten for the recipe
            buyButtons[0].SetActive(false);
        }
    }

    public void AxtHead()
    {
        if (moneyManager.money >= 100)
        {
            //devede 100 frome the money
            moneyManager.DevedeMoney(100);
            //set the button in the spawner to true
            craftButtons[1].SetActive(true);
            //set the item the spawner can pickup now to true in the crafter
            craftButtonsItems[1].SetActive(true);
            //disable the buy butten for the recipe
            buyButtons[1].SetActive(false);
        }
    }

    public void Axt()
    {
        if (moneyManager.money >= 500)
        {
            //devede 100 frome the money
            moneyManager.DevedeMoney(500);
            //set the button in the spawner to true
            craftButtons[2].SetActive(true);
            //set the item the spawner can pickup now to true in the crafter
            craftButtonsItems[2].SetActive(true);
            //disable the buy butten for the recipe
            buyButtons[2].SetActive(false);
        }
    }

    public void Platine()
    {
        if (moneyManager.money >= 15000)
        {
            //devede 100 frome the money
            moneyManager.DevedeMoney(15000);
            //set the button in the spawner to true
            craftButtons[3].SetActive(true);
            //set the item the spawner can pickup now to true in the crafter
            craftButtonsItems[3].SetActive(true);
            //disable the buy butten for the recipe
            buyButtons[3].SetActive(false);
        }
    }

    public void CPU()
    {
        if (moneyManager.money >= 50000)
        {
            //devede 100 frome the money
            moneyManager.DevedeMoney(50000);
            //set the button in the spawner to true
            craftButtons[4].SetActive(true);
            //set the item the spawner can pickup now to true in the crafter
            craftButtonsItems[4].SetActive(true);
            //disable the buy butten for the recipe
            buyButtons[4].SetActive(false);
        }
    }
}
