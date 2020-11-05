using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControlScrpit : MonoBehaviour
{
    public GameObject UpCube;
    public GameObject DownCube;
    public GameObject LeftCube;
    public GameObject RightCube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //This is for the Up and W key
        if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W))
        {
            UpCube.GetComponent<MeshRenderer>().material.color = new Color(0,1,0);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow)|| Input.GetKeyUp(KeyCode.W))
        {
            UpCube.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
        }
        

        //This is for the Down and S key
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            DownCube.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            DownCube.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
        }


        //This is for the Left and A Key
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            LeftCube.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            LeftCube.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
        }


        //This is for the Right and D Key
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            RightCube.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            RightCube.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1);
        }


    }
}
