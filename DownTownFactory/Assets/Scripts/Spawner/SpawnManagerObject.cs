using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerObject : MonoBehaviour
{
    [Header("0 = Aluminium, 1 = Copper, 2 = Diamond, 3 = Gold, 4 = Iron")]
    public GameObject[] items;

    public int spawnerID;
    
    public int itemSeleted = 4;

    public int spawnerNumber;
    
    public Transform spawnPos;

    private void Start()
    {
        StartCoroutine(StoneSPawner());
    }
    
    private IEnumerator StoneSPawner()
    {
        yield return new WaitForSeconds(2);
        GameObject x = Instantiate(items[itemSeleted]);
        x.transform.position = spawnPos.position;
        switch (transform.rotation.y)
        {
            //0
            case 0f:
                x.GetComponent<Rigidbody>().AddForce(Vector3.right * 6f, ForceMode.Impulse);
                break;
            //90
            case 0.7071068f:
                x.GetComponent<Rigidbody>().AddForce(Vector3.back * 6f, ForceMode.Impulse);
                break;
            //-90
            case -0.7071068f:
                x.GetComponent<Rigidbody>().AddForce(Vector3.forward * 6f, ForceMode.Impulse);
                break;
            //180
            case 1:
                x.GetComponent<Rigidbody>().AddForce(Vector3.left * 6f, ForceMode.Impulse);
                break;
            //-180
            case -1:
                x.GetComponent<Rigidbody>().AddForce(Vector3.left * 6f, ForceMode.Impulse);
                break;
        }
        StartCoroutine(StoneSPawner());
    }
}
