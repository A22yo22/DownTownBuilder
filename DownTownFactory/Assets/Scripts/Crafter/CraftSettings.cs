using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftSettings : MonoBehaviour
{
    //the selected craftmode
    public string craftMoeSeleted;

    //Craftmode Selected text
    public TMP_Text craftModeSlecetedInMenue;

    //all recipes that are in the game
    [Header("0 = Stick, 1 = Head, 2 = None, 3 = Axt, 4 = Platine, 5 = CPU")]
    public GameObject[] craftRezept;

    //GaneObject of the craft menue collection
    public GameObject CraftMenueOBJ;
    
    //gameObjt with the CraftScript on it(the script is on every spawner)
    public GameObject crafterOBJ;
    
    void Update()
    {
        if (CraftMenueOBJ.activeInHierarchy == true)
        {
            string craftMode = crafterOBJ.GetComponent<CraftScript>().craftMode;
            //set craftMode to None
            if (craftMode == "")
            {
                //sets the text on the left side
                craftModeSlecetedInMenue.text = "None";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }
                craftRezept[2].SetActive(true);
            }
            //set craftMode to sick
            else if (craftMode == "stick")
            {
                craftModeSlecetedInMenue.text = "Axt Stick";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }
                craftRezept[0].SetActive(true);
            }
            //set craftMode to head
            else if (craftMode == "head")
            {
                craftModeSlecetedInMenue.text = "Axt Head";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }
                craftRezept[1].SetActive(true);
            }
            //set craftMode to axt
            else if (craftMode == "axt")
            {
                craftModeSlecetedInMenue.text = "Axt";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }
                craftRezept[3].SetActive(true);
            }
            //set craftMode to platine
            else if (craftMode == "platine")
            {
                craftModeSlecetedInMenue.text = "Circuit Board";
                for (int i = 0; i < craftRezept.Length; i++)
                {
                    craftRezept[i].SetActive(false);
                }

                craftRezept[4].SetActive(true);
            }
            //set craftMode to cpu
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
    
    //sets the deploys the CraftMode
    public void SetCrafterMode()
    {
        crafterOBJ.GetComponent<CraftScript>().craftMode = craftMoeSeleted;
        crafterOBJ.GetComponent<CraftScript>().StartCrafting();
        StartCoroutine(SetItemPickup());
    }

    //calls the SetItemPickp function on the crafterScript
    IEnumerator SetItemPickup()
    {
        yield return new WaitForSeconds(0.1f);
        crafterOBJ.GetComponent<CraftScript>().SetItemsPickedp();
        StartCoroutine(SetItemPickup());
    }

    //CraftMode None Button
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
    
    //CraftMode Stick Button
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
    
    //CraftMode Head Button
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
    
    //CraftMode Axt Button
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
    
    //CraftMode Platine Button
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
    
    //CraftMode CPU Button
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
