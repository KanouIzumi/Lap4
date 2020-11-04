﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCude_PositiveZDirection : MonoBehaviour
{
    float speed = 10f;
    float zLimit = 27.5f;
    float zstart = 1f;
    bool AtZLimit = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < zLimit && AtZLimit)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed); //true
        }

        else if (transform.position.z > zstart && !AtZLimit)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed); //false
        }

        else
        {
            AtZLimit = !AtZLimit;
         }
        
    }
}
