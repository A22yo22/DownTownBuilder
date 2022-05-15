using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Rezepte : MonoBehaviour
{
    public MoneyManager moneyManager;
    
    [Header("0 = AxtStick, 1 = AxtHead, 2 = Axt, 3 = Platine")]
    public GameObject[] craftButtons;
    public GameObject[] craftButtonsItems;
    public GameObject[] buyButtons;

    public void AxtStick()
    {
        if (moneyManager.money >= 100)
        {
            moneyManager.DevedeMoney(100);
            craftButtons[0].SetActive(true);
            craftButtonsItems[0].SetActive(true);
            buyButtons[0].SetActive(false);
        }
    }

    public void AxtHead()
    {
        if (moneyManager.money >= 100)
        {
            moneyManager.DevedeMoney(100);
            craftButtons[1].SetActive(true);
            craftButtonsItems[1].SetActive(true);
            buyButtons[1].SetActive(false);
        }
    }

    public void Axt()
    {
        if (moneyManager.money >= 500)
        {
            moneyManager.DevedeMoney(500);
            craftButtons[2].SetActive(true);
            craftButtonsItems[2].SetActive(true);
            buyButtons[2].SetActive(false);
        }
    }

    public void Platine()
    {
        if (moneyManager.money >= 15000)
        {
            moneyManager.DevedeMoney(15000);
            craftButtons[3].SetActive(true);
            craftButtonsItems[3].SetActive(true);
            buyButtons[3].SetActive(false);
        }
    }

    public void CPU()
    {
        if (moneyManager.money >= 50000)
        {
            moneyManager.DevedeMoney(50000);
            craftButtons[4].SetActive(true);
            craftButtonsItems[4].SetActive(true);
            buyButtons[4].SetActive(false);
        }
    }
}
