using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FörderbandSeitenTester : MonoBehaviour
{
    //GameObject with the boxcolider on it
    public GameObject setBoxCollOBJ;
    
    private void OnTriggerStay(Collider other)
    {
        //if an item enters from a site set the boxcollider to a smaler size
        //so that the iten don´t get emedialty teleported in the mittle
        setBoxCollOBJ.GetComponent<BoxCollider>().size = new Vector3(14.4f, 2f, 2f);
    }
}
