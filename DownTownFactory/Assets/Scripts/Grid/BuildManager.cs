using System.Diagnostics;
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
        public int[] itemsAmount;

        public int spawnerID = 1;
        
        public GameObject bfSpawn;

        public GameObject[] allObjectsSpawned = new GameObject[2500];
        
        public MoneyManager moneymanagerScript;
        public CraftSettings craftSettings;
        public PlacedObjectSaverManager placedObjectSaverManager;

        public float objectRot;

        public TMP_Text[] ItemsAmountObjects;
        
        [Header("0 = aluminium, 1 = wood, 2 diamond, 3 = gold, 4 = iron, 5 = stick, 6 = head, 7 = axt, 8 = Platine, 9 = CPU")]
        public TMP_Text[] crafterItemsAmount;

        public AudioSource audioSource1;
        public AudioSource audioSource2;
        public AudioClip[] placeSound;
        public AudioClip[] clickSound;
        public AudioClip[] buySound;
        public AudioClip[] cantbuySound;

        void Start()
        {
            moneymanagerScript = FindObjectOfType<MoneyManager>();
            SetItemsAmount();
        }

        public void SetItemsAmount()
        {
            ItemsAmountObjects[0].text = itemsAmount[1].ToString();
            ItemsAmountObjects[1].text = itemsAmount[0].ToString();
            ItemsAmountObjects[2].text = itemsAmount[2].ToString();
            ItemsAmountObjects[3].text = itemsAmount[3].ToString();
        }
        
        public bool itemSlected = false;
        public int itemArraySelected;
        public int itemArraySelectedPos;
        
        void Update()
        {
            MousWeelRot();
            if (itemSlected)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 6))
                        {
                            if (hit.collider.tag == "Place")
                            {
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

            if (Input.GetMouseButtonDown(1))
            {
                itemSlected = false;
                Destroy(bfSpawn);
            }
        }

        private int allObjectsSPawnedArrayCount;
        public void SpawnObjectsManager(int itemAmountPos, RaycastHit hit, string spawnedName = "")
        {
            placedObjectSaverManager.placePos[itemArraySelectedPos] = (int)hit.collider.gameObject.GetComponent<Manger>().gameObject.transform.position.x;
            placedObjectSaverManager.placePos[itemArraySelectedPos + 1] = (int)hit.collider.gameObject.GetComponent<Manger>().gameObject.transform.position.z;
            placedObjectSaverManager.placedRot[itemArraySelected] = (int)objectRot;
            placedObjectSaverManager.placedObject[itemArraySelected] = spawnedName;
            itemArraySelected++;
            itemArraySelectedPos += 2;
            
            itemsAmount[itemAmountPos]--;
            
            hit.collider.gameObject.GetComponent<Manger>().crafterItemsAmount = crafterItemsAmount;
            hit.collider.gameObject.GetComponent<Manger>().BuildManager(objects[objectSelected], objectRot, spawnedName, 0, spawnerID);
            spawnerID++;

            allObjectsSpawned[allObjectsSPawnedArrayCount] = objects[objectSelected];
            allObjectsSPawnedArrayCount++;
            
            bfSpawn.transform.position = new Vector3(-100, -10, 10);
            SetItemsAmount();
            
            audioSource1.clip = placeSound[Random.Range(0, placeSound.Length)];
            audioSource1.Play();
        }
        
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
        
        //Build Stuff
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
        
        //Buy Stuff
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