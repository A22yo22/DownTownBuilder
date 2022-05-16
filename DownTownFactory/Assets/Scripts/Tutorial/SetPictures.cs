using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SetPictures : MonoBehaviour
{
    //referance to the pictures
    public Sprite[] images;

    //gameobject on wich the pictures get spawned
    public GameObject image;

    //all objects that have nothing to do with the tutorial
    //these objects get visabel after the tutorial ended
    public GameObject[] notTutorialObjects;

    //tutorialPlayed is used to see if the tutorial got played
    public bool tutorialPlayed = false;

    //referace to some Scripts
    public SaveAndLoadManager saveAndLoadManager;

    void Start()
    {
        //loads the saved game files
        saveAndLoadManager.Load();
    }
    
    private int x;
    void Update()
    {
        //if tutorial wasn´t played
        if (!tutorialPlayed)
        {
            //left mouse button pressed
            if (Input.GetMouseButtonDown(0))
            {
                //skipes throu the tutorial
                if (x <= images.Length - 2)
                {
                    x++;
                    image.GetComponent<Image>().sprite = images[x];
                }
                else
                {
                    //ends tutorial

                    //sets the tutorialPlayed to true
                    tutorialPlayed = true;
                    //saves the game
                    saveAndLoadManager.Save();
                    //disabels the tutorial object
                    image.SetActive(false);
                }
            }
        }
        else
        {
            //sets all none tutorial objects visabel
            for (int i = 0; i < notTutorialObjects.Length; i++)
            {
                notTutorialObjects[i].SetActive(true);
            }
            //disabels the tutorial object
            image.SetActive(false);
            //and finaly destroys the tutorial object
            Destroy(gameObject);
        }
    }
}