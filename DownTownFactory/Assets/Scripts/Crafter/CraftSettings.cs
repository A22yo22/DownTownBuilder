using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftSettings : MonoBehaviour
{
    public string craftMoeSeleted;

    public TMP_Text craftModeSlecetedInMenue;
    [Header("0 = Stick, 1 = Head, 2 = None, 3 = Axt, 4 = Platine, 5 = CPU")]
    public GameObject[] craftRezept;

    public GameObject CraftMenueOBJ;
    
    public GameObject crafterOBJ;
    
    void Update()
    {
        if (CraftMenueOBJ.activeInHierarchy == true)
        {
            string craftMode = crafterOBJ.GetComponent<CraftScript>().craftMode;
            if (craftMode == "")
            {
                craftModeSlecetedInMenue.text = "None";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }
                craftRezept[2].SetActive(true);
            }
            else if (craftMode == "stick")
            {
                craftModeSlecetedInMenue.text = "Axt Stick";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }
                craftRezept[0].SetActive(true);
            }
            else if (craftMode == "head")
            {
                craftModeSlecetedInMenue.text = "Axt Head";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }
                craftRezept[1].SetActive(true);
            }
            else if (craftMode == "axt")
            {
                craftModeSlecetedInMenue.text = "Axt";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }
                craftRezept[3].SetActive(true);
            }
            else if (craftMode == "platine")
            {
                craftModeSlecetedInMenue.text = "Circuit Board";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }

                craftRezept[4].SetActive(true);
            }
            else if (craftMode == "cpu")
            {
                craftModeSlecetedInMenue.text = "CPU";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }

                craftRezept[5].SetActive(true);
            }
        }
    }
    
    public void SetCrafterMode()
    {
        crafterOBJ.GetComponent<CraftScript>().craftMode = craftMoeSeleted;
        crafterOBJ.GetComponent<CraftScript>().StartCrafting();
        StartCoroutine(SetItemPickup());
    }

    IEnumerator SetItemPickup()
    {
        yield return new WaitForSeconds(0.1f);
        crafterOBJ.GetComponent<CraftScript>().SetItemsPickedp();
        StartCoroutine(SetItemPickup());
    }

    public void None()
    {
        craftMoeSeleted = "";
        craftModeSlecetedInMenue.text = "None";
        for (int i = 0; i < craftRezept.Length; i++)
        {
            craftRezept[i].SetActive(false);
        }
        craftRezept[2].SetActive(true);
        SetCrafterMode();
    }
    
    public void Stick()
    {
        craftMoeSeleted = "stick";
        craftModeSlecetedInMenue.text = "Stick";
        for (int i = 0; i < craftRezept.Length; i++)
        {
            craftRezept[i].SetActive(false);
        }
        craftRezept[0].SetActive(true);
        SetCrafterMode();
    }
    
    public void Head()
    {
        craftMoeSeleted = "head";
        craftModeSlecetedInMenue.text = "Head";
        for (int i = 0; i < craftRezept.Length; i++)
        {
            craftRezept[i].SetActive(false);
        }
        craftRezept[1].SetActive(true);
        SetCrafterMode();
    }
    
    public void Axt()
    {
        craftMoeSeleted = "axt";
        craftModeSlecetedInMenue.text = "Axt";
        for (int i = 0; i < craftRezept.Length; i++)
        {
            craftRezept[i].SetActive(false);
        }
        craftRezept[3].SetActive(true);
        SetCrafterMode();
    }
    
    public void Platine()
    {
        craftMoeSeleted = "platine";
        craftModeSlecetedInMenue.text = "Circuit Board";
        for (int i = 0; i < craftRezept.Length; i++)
        {
            craftRezept[i].SetActive(false);
        }
        craftRezept[4].SetActive(true);
        SetCrafterMode();
    }
    
    public void CPU()
    {
        craftMoeSeleted = "cpu";
        craftModeSlecetedInMenue.text = "CPU";
        for (int i = 0; i < craftRezept.Length; i++)
        {
            craftRezept[i].SetActive(false);
        }
        craftRezept[5].SetActive(true);
        SetCrafterMode();
    }
}
