using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public GameObject scoreText;
    float SpaceCounter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<Text>().text = "Start Function";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceCounter++;
            Debug.Log("SpaceBarCounter:" +SpaceCounter);
        }
        scoreText.GetComponent<Text>().text = "Spacebar: " + SpaceCounter.ToString();
    }
}
