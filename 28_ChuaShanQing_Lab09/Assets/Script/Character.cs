using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject Location;
    public float speed;
    public float rotateSpeed;
    


    // Start is called before the first frame update
    void Start()
    {
        Location.GetComponent<Text>().text = "Start Function";

        Location.GetComponent<Text>().text = ("Position: " + (GameObject.FindGameObjectWithTag("Player").transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        Location.GetComponent<Text>().text = ("Position: " + (GameObject.FindGameObjectWithTag("Player").transform.position));

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, rotateSpeed * -Time.deltaTime, 0));
        }
    }

}

