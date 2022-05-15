using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        //gets velocety of the item that is in the boxcollider
        float y = other.GetComponent<Rigidbody>().velocity.y;
        
        //depending on the roration of the convoyerbelt the item gets a continius velocity
        //in the right diriction
        switch (transform.rotation.y)
        {
            case 0f:
                other.GetComponent<Rigidbody>().velocity = new Vector3(3f, y, 0);
                break;
            case 0.7071068f:
                other.GetComponent<Rigidbody>().velocity = new Vector3(0, y, -3f);
                break;
            case -0.7071068f:
                other.GetComponent<Rigidbody>().velocity = new Vector3(0, y, 3f);
                break;
            case 1:
                other.GetComponent<Rigidbody>().velocity = new Vector3(-3f, y, 0);
                break;
            case -1:
                other.GetComponent<Rigidbody>().velocity = new Vector3(-3f, y, 0);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if an item enters the boxcolider it gets directly teleported into the center of the convoyerbelt
        Vector3 x;
        switch (transform.rotation.y)
        {
            case 0f:
                x = other.gameObject.transform.position;
                other.gameObject.transform.position = new Vector3(x.x, x.y, transform.position.z);
                break;
            case 0.7071068f:
                x = other.gameObject.transform.position;
                other.gameObject.transform.position = new Vector3(transform.position.x, x.y, x.z);
                break;
            case -0.7071068f:
                x = other.gameObject.transform.position;
                other.gameObject.transform.position = new Vector3(transform.position.x, x.y, x.z);
                break;
            case 1:
                x = other.gameObject.transform.position;
                other.gameObject.transform.position = new Vector3(x.x, x.y, transform.position.z);
                break;
            case -1:
                x = other.gameObject.transform.position;
                other.gameObject.transform.position = new Vector3(x.x, x.y, transform.position.z);
                break;
        }
    }
}
