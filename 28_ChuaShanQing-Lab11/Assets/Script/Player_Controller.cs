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
            if (Input.GetKey(KeyCode.W)) //go forward
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            if (Input.GetKey(KeyCode.S)) // go backward
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            if (Input.GetKey(KeyCode.A)) // go left
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                playerAnim.SetBool("IsWalkBool", false);
            }

            if (Input.GetKey(KeyCode.D)) // go right
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAnim.SetBool("IsWalkBool", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
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

