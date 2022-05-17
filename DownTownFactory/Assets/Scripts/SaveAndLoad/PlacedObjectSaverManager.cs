using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObjectSaverManager : MonoBehaviour
{
    //Object possition, 0=x 1=z
    public int[] placePos;
    
    //Object Rotation, 0=rot
    public int[] placedRot;

    //Object Names 0=Name
    public string[] placedObject;
    
    //Spawner item selected
    public int[] itemSelectedSpw;
}