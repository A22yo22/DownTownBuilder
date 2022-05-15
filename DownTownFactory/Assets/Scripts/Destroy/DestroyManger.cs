using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class DestroyManger : MonoBehaviour
{
    public BuildManager buildManager;
    
    public bool destroMode = false;

    public AudioSource audioSource;
    public AudioClip[] destroySound;
    public AudioClip[] openSound;
    
    
    void Update()
    {
        if (destroMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(!buildManager.itemSlected)
                {
                    if (!EventSystem.current.IsPointerOverGameObject())
                    {
                        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray2, out RaycastHit hit, Mathf.Infinity))
                        {
                            if (hit.collider.gameObject.tag == "Destroy")
                            {
                                audioSource.clip = destroySound[Random.Range(0, destroySound.Length)];
                                audioSource.Play();
                                Destroy(hit.collider.transform.root.gameObject);
                                if (Physics.Raycast(hit.collider.transform.position, -Vector3.up, out RaycastHit hit2, Mathf.Infinity, 6))
                                {
                                    hit2.collider.transform.root.gameObject.GetComponent<Manger>().SetFree();
                                }
                            }
                        }
                    }
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                audioSource.clip = openSound[Random.Range(0, openSound.Length)];
                audioSource.Play();
                destroMode = false;
            }
        }
    }

    public void SetDeleteMode()
    {
        audioSource.clip = openSound[Random.Range(0, openSound.Length)];
        audioSource.Play();
        destroMode = true;
    }
}
