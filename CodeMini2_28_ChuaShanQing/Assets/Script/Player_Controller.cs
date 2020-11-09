using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody playerRb;

    public GameObject MoveCube;//referencing the object

    float jumpForce = 8f;
    bool OnAir;

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

      
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("MoveCube"))
        {
            OnAir = false;
        }

        if (collision.gameObject.CompareTag("GamePlane"))
        {
            OnAir = false;
        }

    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnAir == false)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            OnAir = true;
        }
    }


}
