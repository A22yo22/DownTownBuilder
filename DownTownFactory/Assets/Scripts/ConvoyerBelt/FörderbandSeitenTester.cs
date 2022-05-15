using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FörderbandSeitenTester : MonoBehaviour
{
    public GameObject setBoxCollOBJ;
    
    private void OnTriggerStay(Collider other)
    {
        setBoxCollOBJ.GetComponent<BoxCollider>().size = new Vector3(14.4f, 2f, 2f);
    }
}
