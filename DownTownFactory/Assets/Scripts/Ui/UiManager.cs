using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    //reference to the UI objects
    public GameObject upgrades;
    public GameObject buyMashins;
    public GameObject recipes;
    
    //reference to the spawner and crafter menu
    public GameObject spawnerItemSette;
    public GameObject craftModeSette;

    //reference to the sttings panel
    public GameObject settingsMenue;

    private bool x;
    
    void Update()
    {
        //Opens/closes the Sttings
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (x)
            {
                //disabels the Settings
                x = false;
                settingsMenue.SetActive(false);
            }
            else 
            {
                //enabeld the settings
                x = true;
                settingsMenue.SetActive(true);
            }
        }
    }

    //opens the build menue
    public void SetBuildMode()
    {
        recipes.SetActive(false);
        buyMashins.SetActive(false);
        upgrades.SetActive(true);
    }
    
    //opens the Buy menue
    public void SetBuyMode()
    {
        upgrades.SetActive(false);
        recipes.SetActive(false);
        buyMashins.SetActive(true);
    }

    //opens the Recipes menue
    public void SetRecipesMenu()
    {
        upgrades.SetActive(false);
        buyMashins.SetActive(false);
        recipes.SetActive(true);
    }
    
    //closes the spawner
    public void CloseSpawnManager()
    {
        spawnerItemSette.SetActive(false);
    }
    
    //closes craft Manager
    public void CloseCraftManager()
    {
        craftModeSette.SetActive(false);
    }

    //opens settings menue
    public void SetSettingsTrue()
    {
        settingsMenue.SetActive(true);
        x = true;
    }
    
    //closes settings menue
    public void SetSettingsFalse()
    {
        settingsMenue.SetActive(false);
        x = false;
    }

    //quids the game
    public void Quid()
    {
        saveAndLoadManager.Save();
        Application.Quit();
    }
    
    //Save and Load

    public SaveAndLoadManager saveAndLoadManager;
    
    //Saves
    public void Save()
    {
        saveAndLoadManager.Save();
    }

    //loads
    public void Load()
    {
        saveAndLoadManager.Load();
    }
}
