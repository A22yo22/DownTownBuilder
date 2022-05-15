using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public GameObject upgrades;
    public GameObject buyMashins;
    public GameObject recipes;
    
    public GameObject spawnerItemSette;
    public GameObject craftModeSette;

    public GameObject settingsMenue;

    private bool x;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (x)
            {
                x = false;
                settingsMenue.SetActive(false);
            }
            else
            {
                x = true;
                settingsMenue.SetActive(true);
            }
        }
    }
    
    public void SetBuildMode()
    {
        recipes.SetActive(false);
        buyMashins.SetActive(false);
        upgrades.SetActive(true);
    }
    
    public void SetBuyMode()
    {
        upgrades.SetActive(false);
        recipes.SetActive(false);
        buyMashins.SetActive(true);
    }

    public void SetRecipesMenu()
    {
        upgrades.SetActive(false);
        buyMashins.SetActive(false);
        recipes.SetActive(true);
    }
    
    public void CloseSpawnManager()
    {
        spawnerItemSette.SetActive(false);
    }
    
    public void CloseCraftManager()
    {
        craftModeSette.SetActive(false);
    }

    public void SetSettingsTrue()
    {
        settingsMenue.SetActive(true);
        x = true;
    }
    
    public void SetSettingsFalse()
    {
        settingsMenue.SetActive(false);
        x = false;
    }

    public void Quid()
    {
        saveAndLoadManager.Save();
        Application.Quit();
    }
    
    //Save and Load

    public SaveAndLoadManager saveAndLoadManager;
    
    public void Save()
    {
        saveAndLoadManager.Save();
    }

    public void Load()
    {
        saveAndLoadManager.Load();
    }
}
