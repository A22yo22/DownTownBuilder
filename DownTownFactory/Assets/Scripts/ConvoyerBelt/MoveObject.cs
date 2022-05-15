using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject iron;
    
    private void OnTriggerStay(Collider other)
    {
        float y = other.GetComponent<Rigidbody>().velocity.y;
        
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

    /*public GameObject[] gMJArray1;
    private int gMJInt1;
    
    public GameObject[] gMJArray2;
    private int gMJInt2;*/
    
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Item1")
        {
            gMJArray1[gMJInt1] = other.gameObject;
            gMJInt1++;
            
            if (gMJInt1 >= 10)
            {
                gMJInt1 = -10;
                for (int i = 0; i < 10; i++)
                {
                    Destroy(gMJArray1[i]);
                    gMJArray1[i] = null;
                }
                GameObject xGMJ = Instantiate(iron);
                xGMJ.transform.position = transform.position;
                xGMJ.tag = "Item2";
                xGMJ.GetComponent<Worth>().worth = 50;
            }
        }
        else if (other.gameObject.tag == "Item2")
        {
            
            gMJArray2[gMJInt2] = other.gameObject;
            gMJInt2++;
            
            if (gMJInt2 >= 10)
            {
                gMJInt1 = -10;
                for (int i = 0; i < 10; i++)
                {
                    Destroy(gMJArray2[i]);
                    gMJArray2[i] = null;
                }
                GameObject xGMJ = Instantiate(iron);
                xGMJ.transform.position = transform.position;
                xGMJ.tag = "Item2";
                xGMJ.GetComponent<Worth>().worth = 500;
            }
        }*/

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

    private void OnTriggerExit(Collider other)
    {
        /*if (other.gameObject.tag == "Item1")
        {
            gMJInt1--;
        }*/
    }
}
