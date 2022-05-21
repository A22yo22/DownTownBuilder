using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using TMPro;

namespace Assets.Scripts
{
    public class BuildManager : MonoBehaviour
    {
        [Header("0 = Förderband, 1 = Spawner, 2 = Seller, 3 = Crafter")]
        public GameObject[] objects;
        [Header("0 = Spawner, 1 = Förderband, 2 = Seller, 3 = Crafter")]
        public GameObject[] objectsVS;
        [Header("0 = Förderband, 1 = Spawner, 2 = Seller, 3 = Crafter")]
        public int objectSelected;
        [Header("0 = Förderband, 1 = Spawner, 2 = Seller, 3 = Crafter")]
        public List<int> itemsAmount;

        //the ID that the spawner get when he gets spawned
        public int spawnerID = 1;
        
        //when a object to build is selected the "previous object" is linked here
        public GameObject bfSpawn;

        //here all objects that get spawned are linked here to access them lateer
        public GameObject[] allObjectsSpawned = new GameObject[2500];
        
        //references to some scripts
        public MoneyManager moneymanagerScript;
        public CraftSettings craftSettings;
        public PlacedObjectSaverManager placedObjectSaverManager;
        public SaveWithList saveWithList;

        //rotation of the objects
        public float objectRot;

        //the amount of objects left are shown in this Text
        //for example you have 4 spawner left the four gets shown here
        public TMP_Text[] ItemsAmountObjects;
        
        //displace again the items left but this time in the spawner
        [Header("0 = aluminium, 1 = wood, 2 diamond, 3 = gold, 4 = iron, 5 = stick, 6 = head, 7 = axt, 8 = Platine, 9 = CPU")]
        public TMP_Text[] crafterItemsAmount;

        //sounds 
        public AudioSource audioSource1;
        public AudioSource audioSource2;
        public AudioClip[] placeSound;
        public AudioClip[] clickSound;
        public AudioClip[] buySound;
        public AudioClip[] cantbuySound;

        void Start()
        {
            //get the money Script
            moneymanagerScript = FindObjectOfType<MoneyManager>();

            //updates the objects left in the inventory
            SetItemsAmount();
        }

        //updates the objects left in the inventory
        public void SetItemsAmount()
        {
            ItemsAmountObjects[0].text = itemsAmount[1].ToString();
            ItemsAmountObjects[1].text = itemsAmount[0].ToString();
            ItemsAmountObjects[2].text = itemsAmount[2].ToString();
            ItemsAmountObjects[3].text = itemsAmount[3].ToString();
        }
        
        //if an item buttun was pressed set itemSelected to true
        public bool itemSlected = false;

        //used to get the pos names rot und itemsInSpw
        public int itemArraySelected;
        public int itemArraySelectedPos;
        
        void Update()
        {
            //gets mouse rotation
            MousWeelRot();

            //if item selected 
            if (itemSlected)
            {
                //left mousebutton pressed
                if (Input.GetMouseButtonDown(0))
                {
                    //not on an UI
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        //shoot ray to a grid
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 6))
                        {
                            //if raycast it a tile / place
                            if (hit.collider.tag == "Place")
                            {
                                //Spawn the mashine
                                switch (objectSelected)
                                { 
                                    case 0:
                                        if (itemsAmount[0] > 0)
                                        {
                                            SpawnObjectsManager(0, hit, "Förderband");
                                        }
                                        break;
                                    
                                    case 1:
                                        if (itemsAmount[1] > 0)
                                        {
                                            SpawnObjectsManager(1, hit, "Spawner");
                                            //Set eine array die sagt welcher spawner es ist
                                        }
                                        break;
                                    
                                    case 2:
                                        if (itemsAmount[2] > 0)
                                        {
                                            SpawnObjectsManager(2, hit, "Seller");
                                        }
                                        break;
                                    
                                    case 3:
                                        if (itemsAmount[3] > 0)
                                        {
                                            SpawnObjectsManager(3, hit, "Crafter");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                //play sound
                                audioSource2.clip = cantbuySound[Random.Range(0, cantbuySound.Length)];
                                audioSource2.Play();
                            }
                        }
                    }
                }


                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray2, out RaycastHit hit2, Mathf.Infinity, 6))
                    {
                        if (hit2.collider.tag == "Place")
                        {
                            //spawn previus
                            switch (objectSelected)
                            {
                                case 0:
                                    hit2.collider.gameObject.GetComponent<Manger>().Vorshow(bfSpawn, objectRot);
                                    break;
                                case 1:
                                    hit2.collider.gameObject.GetComponent<Manger>().Vorshow(bfSpawn, objectRot);
                                    break;
                                case 2:
                                    hit2.collider.gameObject.GetComponent<Manger>().Vorshow(bfSpawn, objectRot);
                                    break;
                                case 3:
                                    hit2.collider.gameObject.GetComponent<Manger>().Vorshow(bfSpawn, objectRot);
                                    break;
                            }
                        }
                    }
                }
            }

            //if right mouse button is pressed exit Placemode
            if (Input.GetMouseButtonDown(1))
            {
                itemSlected = false;
                Destroy(bfSpawn);
            }
        }

        private int allObjectsSPawnedArrayCount;
        //Spawns the objects
        public void SpawnObjectsManager(int itemAmountPos, RaycastHit hit, string spawnedName = "")
        {

            saveWithList.placePos.Add((int)hit.collider.gameObject.GetComponent<Manger>().gameObject.transform.position.x);
            saveWithList.placePos.Add((int)hit.collider.gameObject.GetComponent<Manger>().gameObject.transform.position.z);
            saveWithList.placeRot.Add((int)objectRot);
            saveWithList.placedObject.Add(spawnedName);
            if(spawnedName == "Spawner")
            {
                hit.collider.gameObject.GetComponent<Manger>().BuildManager(objects[objectSelected], objectRot, spawnedName, 0, spawnerID);
                saveWithList.spawnerIDForLoading.Add(spawnerID);
                spawnerID++;
                saveWithList.itemSelectedSpw.Add(0);
            }
            else
            {
                hit.collider.gameObject.GetComponent<Manger>().BuildManager(objects[objectSelected], objectRot, spawnedName, 0);
            }
            
            itemsAmount[itemAmountPos]--;
            
            //Builds the object
            hit.collider.gameObject.GetComponent<Manger>().crafterItemsAmount = crafterItemsAmount;

            //sets the object in the array to access it later
            allObjectsSpawned[allObjectsSPawnedArrayCount] = objects[objectSelected];
            allObjectsSPawnedArrayCount++;
            
            //refreches the UI
            bfSpawn.transform.position = new Vector3(-100, -10, 10);
            SetItemsAmount();
            
            //plays sound
            audioSource1.clip = placeSound[Random.Range(0, placeSound.Length)];
            audioSource1.Play();
        }
        
        //gets the mouseweel rotation to rotate the mashines
        void MousWeelRot()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) //FW
            {
                objectRot += 90;
                if (objectRot == 360)
                {
                    objectRot = 0;
                }
                else if (objectRot == 270)
                {
                    objectRot = -90;
                }
            }
            
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) //BW
            {
                objectRot -= 90;
                if (objectRot == -360)
                {
                    objectRot = 0;
                }
                else if (objectRot == -270)
                {
                    objectRot = 90;
                }
            }
        }
        
        //Builds the spawner
        public void SetSpawner()
        {
            objectSelected = 1;
            Destroy(bfSpawn);
            bfSpawn = Instantiate(objectsVS[0]);
            bfSpawn.transform.position = new Vector3(-100, 0, 0);
            itemSlected = true;
            audioSource1.clip = clickSound[Random.Range(0, clickSound.Length)];
            audioSource1.Play();
        }

        //Builds the spawner
        public void SetLaufband()
        {
            objectSelected = 0;
            Destroy(bfSpawn);
            bfSpawn = Instantiate(objectsVS[1]);
            bfSpawn.transform.position = new Vector3(-100, 0, 0);
            itemSlected = true;
            audioSource1.clip = clickSound[Random.Range(0, clickSound.Length)];
            audioSource1.Play();
        }
        
        //Builds the Seller
        public void SetSeller()
        {
            objectSelected = 2;
            Destroy(bfSpawn);
            bfSpawn = Instantiate(objectsVS[2]);
            bfSpawn.transform.position = new Vector3(-100, 0, 0);
            itemSlected = true;
            audioSource1.clip = clickSound[Random.Range(0, clickSound.Length)];
            audioSource1.Play();
        }
        
        public void SetCrafter()
        {
            objectSelected = 3;
            Destroy(bfSpawn);
            bfSpawn = Instantiate(objectsVS[3]);
            bfSpawn.transform.position = new Vector3(-100, 0, 0);
            itemSlected = true;
            audioSource1.clip = clickSound[Random.Range(0, clickSound.Length)];
            audioSource1.Play();
        }
        
        //Buy Spawner button
        public void BuySpawner()
        {
            if (moneymanagerScript.money >= 50)
            {
                moneymanagerScript.DevedeMoney(50);
                itemsAmount[1]++;
                SetItemsAmount();
                //Buy sound
            }
            else
            {
                audioSource2.clip = cantbuySound[Random.Range(0, cantbuySound.Length)];
                audioSource2.Play();
            }
        }

        //buy convoyerbelt button
        public void BuyLaufband()
        {
            if (moneymanagerScript.money >= 10)
            {
                moneymanagerScript.DevedeMoney(10);
                itemsAmount[0]++;
                SetItemsAmount();
                //Buy sound
            }
            else
            {
                audioSource2.clip = cantbuySound[Random.Range(0, cantbuySound.Length)];
                audioSource2.Play();
            }
        }

        //buy Seller button
        public void BuySeller()
        {
            if (moneymanagerScript.money >= 50)
            {
                moneymanagerScript.DevedeMoney(50);
                itemsAmount[2]++;
                SetItemsAmount();
                //Buy sound
            }
            else
            {
                audioSource2.clip = cantbuySound[Random.Range(0, cantbuySound.Length)];
                audioSource2.Play();
            }
        }
        
        //buy crafter button
        public void BuyCrafter()
        {
            if (moneymanagerScript.money >= 100)
            {
                moneymanagerScript.DevedeMoney(100);
                itemsAmount[3]++;
                SetItemsAmount();
                //Buy sound
            }
            else
            {
                audioSource2.clip = cantbuySound[Random.Range(0, cantbuySound.Length)];
                audioSource2.Play();
            }
        }
    }
}