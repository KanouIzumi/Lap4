using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    public float speed = 1.5f;
    bool collide;
    int enemyHP = 0;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //go forward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnim.SetBool("IsStrafe", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("IsStrafe", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("TrigAttack");
        }

        if (Input.GetKey(KeyCode.S)) // go backward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.SetBool("IsStrafe", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("IsStrafe", false);
        }

        if (Input.GetKey(KeyCode.A)) // go left
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAnim.SetBool("IsStrafe", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.SetBool("IsStrafe", false);
        }

        if (Input.GetKey(KeyCode.D)) // go right
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playerAnim.SetBool("IsStrafe", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("IsStrafe", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            playerAnim.SetTrigger("TrigAttack");
            enemyHP++;

            if (collide == true)
            {
                if (enemyHP == 5)
                {
                    Destroy(Enemy);
                }
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Poll"))
        {
            playerAnim.SetTrigger("TrigDeath");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            collide = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            collide = false;
        }
    }


}

