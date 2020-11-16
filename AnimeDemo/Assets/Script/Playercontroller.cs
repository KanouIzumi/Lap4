using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    float HP = 10f;
    public GameObject healthPointText;

    public Animator playerAnim;
    public Rigidbody playerRb;


    bool IsOnPlane;
    // Start is called before the first frame update
    void Start()
    {
        healthPointText.GetComponent<Text>().text = "Start Function";
        healthPointText.GetComponent<Text>().text = "Health Points: " + HP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //go forward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnim.SetBool("IsMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("IsMove", false);
        }

        if (Input.GetKey(KeyCode.S)) // go backward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.SetBool("IsMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("IsMove", false);
        }

        if (Input.GetKey(KeyCode.A)) // go left
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAnim.SetBool("IsMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.SetBool("IsMove", false);
        }

        if (Input.GetKey(KeyCode.D)) // go right
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playerAnim.SetBool("IsMove", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("IsMove", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsOnPlane)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("TrigFlip");
            IsOnPlane = false;
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
          HP--;
          healthPointText.GetComponent<Text>().text = "Health Points: " + HP.ToString();
            if (HP == 0)
            {
                playerAnim.SetTrigger("TrigDeath");
                speed = 0;
                jumpForce = 0;
            }
        }



    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GamePlane"))
        {
            IsOnPlane = true;
        }
    }
}
