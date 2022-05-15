using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class OpenObjectManager : MonoBehaviour
{
    public UiManager uiManager;
    public CraftSettings craftSettings;
    public SpawnerObjectSelection spawnerObjectSelection;
    public DestroyManger destroyManger;
    public BuildManager buildManager;

    public GameObject spawnerCanves;
    public GameObject crafterCanves;

    public AudioSource audioSource;
    public AudioClip openClip;
    
    void Update()
    {
        if (Input.GetMouseButtonDown((0)))
        {
            if (!destroyManger.destroMode)
            {
                if (!buildManager.itemSlected)
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                        {
                            if (hit.collider.tag == "Destroy")
                            {
                                if (hit.collider.transform.root.tag == "Spawner")
                                {
                                    spawnerCanves.SetActive(true);
                                    spawnerObjectSelection.spawnerOBJ = hit.collider.transform.root.gameObject;
                                    audioSource.clip = openClip;
                                    audioSource.Play();
                                }
                                else if (hit.collider.transform.root.tag == "Crafter")
                                {
                                    crafterCanves.SetActive(true);
                                    craftSettings.crafterOBJ = hit.collider.transform.root.gameObject;
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
