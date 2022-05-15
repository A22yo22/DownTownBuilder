using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public GameObject Tile;
        private Vector3 pos;
        public Vector2 TilleSize;
        
        
        public SaveAndLoadManager saveAndLoadManager;
        
        void Start()
        {
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
