using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        //reference to Tile prefab
        public GameObject Tile;

        //position for the tile to spawn
        private Vector3 pos;

        //Size of the grid
        public Vector2 TilleSize;
        
        //reference to SaveAndLoadManager Script
        public SaveAndLoadManager saveAndLoadManager;
        
        void Start()
        {
            //gets the grid size and sets it int the TileSpawner function
            TileSpawner((int)TilleSize.x, (int)TilleSize.y);
            StartCoroutine(load());
            StartCoroutine(SaveTimer());
        }

        IEnumerator load()
        {
            yield return new WaitForSeconds(0.05f);
            saveAndLoadManager.Load();
        }

        private int posPlace;
        public void TileSpawner(int x, int z)
        {
            pos = new Vector3(5, 0, 5);
            
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < z; j++)
                {
                    posPlace++;
                    pos.x += 10;
                    GameObject g = Instantiate(Tile);
                    g.transform.position = pos;
                    g.GetComponent<Manger>().pos = posPlace;
                }

                pos.z += 10;
                pos.x = 5;
            }
        }
        
        IEnumerator SaveTimer()
        {
            yield return new WaitForSeconds(10);
            saveAndLoadManager.Save();
            StartCoroutine(SaveTimer());
            Debug.Log("Saved");
        }
    }
}
