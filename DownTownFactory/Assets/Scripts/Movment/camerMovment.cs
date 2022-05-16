using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerMovment : MonoBehaviour
{
    //speed the player travelth throu the World
    public float speed;

    void Update()
    {
        //gets the input of the player and moves him in the direction he wants
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
