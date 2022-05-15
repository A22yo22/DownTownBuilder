using JetBrains.Annotations;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class Manger : MonoBehaviour
    {
        public int pos;
        public GameObject Used;
        public GameObject Free;
        public GameObject spawnPos;
        
        [Header("0 = aluminium, 1 = wood, 2 diamond, 3 = gold, 4 = iron, 5 = stick, 6 = head, 7 = axt")]
        public TMP_Text[] crafterItemsAmount;
        
        void Start()
        {
            Used.SetActive(false);
        }


        private int spawnerNumber;
        public void BuildManager(GameObject spawnObject, float rot, string name = "", int itemSelectedSpw = 4, int spawnerID = 0)
        {
            Used.SetActive(true);
            Free.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            spawnObject = Instantiate(spawnObject);
            spawnObject.transform.position = spawnPos.transform.position;
            spawnObject.transform.localRotation = Quaternion.Euler(0, rot, 0);
            if (name == "Spawner")
            {
                spawnObject.GetComponent<SpawnManagerObject>().itemSeleted = itemSelectedSpw;
                spawnObject.GetComponent<SpawnManagerObject>().spawnerNumber = spawnerNumber;
                spawnObject.GetComponent<SpawnManagerObject>().spawnerID = spawnerID;
                spawnerID++;
                spawnerNumber++;
            }
            else if (name == "Crafter")
            {
                spawnObject.GetComponent<CraftScript>().SetItemAnzeiger(crafterItemsAmount);
            }
        }

        public void Vorshow(GameObject vorshauObject, float rot)
        {
            vorshauObject.transform.position = spawnPos.transform.position;
            vorshauObject.transform.localRotation = Quaternion.Euler(0, rot, 0);
        }

        public void SetFree()
        {
            Used.SetActive(false);
            Free.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
