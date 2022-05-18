using JetBrains.Annotations;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class Manger : MonoBehaviour
    {
        public int pos;

        //used mode collection for the tile
        //signals that the tile is used
        public GameObject Used;

        //free mode collection for the tile
        //signals that the tile is free
        public GameObject Free;

        //spawn possition for the mashines
        public GameObject spawnPos;
        
        [Header("0 = aluminium, 1 = wood, 2 diamond, 3 = gold, 4 = iron, 5 = stick, 6 = head, 7 = axt")]
        public TMP_Text[] crafterItemsAmount;
        
        void Start()
        {
            //sets Used collection to false because nothing has plced on it yet 
            Used.SetActive(false);
        }

        //builds and the selected mashine on the tile
        public void BuildManager(GameObject spawnObject, float rot, string name = "", int itemSelectedSpw = 4, int spawnerID = 0)
        {
            //sets used to true because a mashine has plced on it now
            Used.SetActive(true);
            Free.SetActive(false);
            //disables the box collider so nothing can placed on it now
            gameObject.GetComponent<BoxCollider>().enabled = false;

            //instantiats the mashine in the spawnObject
            spawnObject = Instantiate(spawnObject);
            //sets the mashine to the spawn point
            spawnObject.transform.position = spawnPos.transform.position;
            //sets the mashins rotation in the right direction
            spawnObject.transform.localRotation = Quaternion.Euler(0, rot, 0);

            //if the name is set to spawner
            if (name == "Spawner")
            {
                //should LOAD the data of the spawn data if it exists
                spawnObject.GetComponent<SpawnManagerObject>().itemSeleted = itemSelectedSpw;
                spawnObject.GetComponent<SpawnManagerObject>().spawnerID = spawnerID;
                spawnerID++;
            }
            //if name is Crafter
            else if (name == "Crafter")
            {
                //spawns the crafter
                spawnObject.GetComponent<CraftScript>().SetItemAnzeiger(crafterItemsAmount);
            }
        }

        //sets a preview of the object is´s going to spawn
        public void Vorshow(GameObject vorshauObject, float rot)
        {
            //sets the preview object to the spawn possition
            vorshauObject.transform.position = spawnPos.transform.position;
            //and here the rotation
            vorshauObject.transform.localRotation = Quaternion.Euler(0, rot, 0);
        }

        //sets the tile free
        public void SetFree()
        {
            //disabels used mode
            Used.SetActive(false);
            //activates Free mode
            Free.SetActive(true);
            //sets boxcollider to true so the player can spawn mashines again
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
