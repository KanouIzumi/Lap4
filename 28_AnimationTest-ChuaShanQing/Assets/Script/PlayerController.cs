using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
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

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnim.SetTrigger("TrigAttack");
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Poll"))
        {
            playerAnim.SetTrigger("TrigDeath");
        }

    }
}

