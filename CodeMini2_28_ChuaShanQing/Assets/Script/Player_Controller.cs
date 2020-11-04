using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody playerRb;

    public GameObject MoveCube;//referencing the object

    float jumpForce = 8f;
    bool onMoveCube;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * jumpForce);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * jumpForce);

        PlayerJump();

        if(onMoveCube == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, MoveCube.transform.position.z); //to let it move with the move cub
        }
                   
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("MoveCube"))
        {
            onMoveCube = true;
        }
        
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onMoveCube = false;
        }
    }


}
