using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerObject : MonoBehaviour
{
    [Header("0 = Aluminium, 1 = Copper, 2 = Diamond, 3 = Gold, 4 = Iron")]
    public GameObject[] items;

    //spawner id used to keep track of the spawners that get spawned
    //gets apllayed when the spawner gets spawned
    public int spawnerID;
    
    //the item selected to spawn a mashine
    public int itemSeleted = 4;
    
    //possition where the item gets spawned
    public Transform spawnPos;

    //gets the Animator
    public Animator spawnAnimation;

    private void Start()
    {
        //starts the spawner
        StartCoroutine(StoneSPawner());
    }
    
    //function to spawn the items
    private IEnumerator StoneSPawner()
    {
        //waits 2 seconds before spawning
        yield return new WaitForSeconds(2);
        //spawns the item
        GameObject x = Instantiate(items[itemSeleted]);
        //sets the possition of the object to the spawn possiton
        x.transform.position = spawnPos.position;

        //desides in wich diretion the item gets spawned and adds a force in the right direction
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

        //starts the spawn Animation
        spawnAnimation.Play("SpawnAnimation", 0, 0.0f);

        //starts the loop again
        StartCoroutine(StoneSPawner());
    }
}
