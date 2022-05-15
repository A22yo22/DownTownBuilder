using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SetPictures : MonoBehaviour
{
    public Sprite[] images;

    public GameObject image;

    public GameObject[] notTutorialObjects;

    public bool tutorialPlayed = false;

    public SaveAndLoadManager saveAndLoadManager;

    void Start()
    {
        saveAndLoadManager.Load();
    }
    
    private int x;
    void Update()
    {
        if (!tutorialPlayed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (x <= images.Length - 2)
                {
                    x++;
                    image.GetComponent<Image>().sprite = images[x];
                }
                else
                {
                    tutorialPlayed = true;
                    saveAndLoadManager.Save();
                    image.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < notTutorialObjects.Length; i++)
            {
                notTutorialObjects[i].SetActive(true);
            }
            image.SetActive(false);
            Destroy(gameObject);
        }
    }
}