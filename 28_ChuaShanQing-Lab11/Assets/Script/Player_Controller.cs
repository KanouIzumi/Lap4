using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public GameObject healthPointText;
    public float speed;
    public float rotateSpeed;
    public float damageRate;
    public float health;
    bool IsAlive = true;
    public float rotation = 0;
    

    public Animator playerAnim;
    public Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        healthPointText.GetComponent<Text>().text = "Start Function";
        healthPointText.GetComponent<Text>().text = "Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive == true)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //go forward
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0+rotation, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // go backward
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180+rotation, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // go left
            {
                //transform.Translate(Vector3.forward * Time.deltaTime * speed);
                // transform.rotation = Quaternion.Euler(0, -90+rotation, 0);
                rotation -= rotateSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // go right
            {
                //transform.Translate(Vector3.forward * Time.deltaTime * speed);
                //transform.rotation = Quaternion.Euler(0, 90+rotation, 0);
                rotation += rotateSpeed;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            

            if (Input.GetKeyDown(KeyCode.Space)) //Attack
            {
                playerAnim.SetTrigger("AttackTrigger");
            }

        }
        else
        {
            playerAnim.SetBool("IsWalkBool", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Fire" && IsAlive == true)
        {
            health -= damageRate * Time.deltaTime;
            healthPointText.GetComponent<Text>().text = "Health: " + health.ToString();
            if (health <= 0)
            {
                healthPointText.GetComponent<Text>().text = "Health: 0";
                playerAnim.SetTrigger("DeadTrigger");
                IsAlive = false;
            }
        }
    }
}

