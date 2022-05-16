using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class OpenObjectManager : MonoBehaviour
{
    //references to some Scripts
    public UiManager uiManager;
    public CraftSettings craftSettings;
    public SpawnerObjectSelection spawnerObjectSelection;
    public DestroyManger destroyManger;
    public BuildManager buildManager;

    //reference to the spawner Canvs so we can open or close it
    public GameObject spawnerCanves;

    //reference to the crafter Canves so we can open or close it
    public GameObject crafterCanves;

    //sounds
    public AudioSource audioSource;
    public AudioClip openClip;
    
    void Update()
    {
        //if left mouse button is pressed
        if (Input.GetMouseButtonDown((0)))
        {
            //if there isn´t a Build or Craft mode selected
            if (!destroyManger.destroMode)
            {
                if (!buildManager.itemSlected)
                {
                    //player ist pressing on a UI element
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        //shot raycast from the camera to the point the player clickt on the screen
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                        {
                            //if the raycast hits a collider with the tag Destroy
                            //Destry is the collider for mashines 
                            if (hit.collider.tag == "Destroy")
                            {
                                //opens the spawner UI
                                if (hit.collider.transform.root.tag == "Spawner")
                                {
                                    //sets spawner Canvas visabel
                                    spawnerCanves.SetActive(true);
                                    //sets the seleted object to the spawnerObjectSelection spawnerOBJ
                                    //to access the data from the selected object
                                    spawnerObjectSelection.spawnerOBJ = hit.collider.transform.root.gameObject;
                                    //plays sound
                                    audioSource.clip = openClip;
                                    audioSource.Play();
                                }
                                //opens the crafter UI
                                else if (hit.collider.transform.root.tag == "Crafter")
                                {
                                    //sets crafter Canvis to visabel
                                    crafterCanves.SetActive(true);
                                    //sets the seleted object to the craftSettings crafterOBJ
                                    //to access the data from the selected object
                                    craftSettings.crafterOBJ = hit.collider.transform.root.gameObject;
                                    //plays sound
                                    audioSource.clip = openClip;
                                    audioSource.Play();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
