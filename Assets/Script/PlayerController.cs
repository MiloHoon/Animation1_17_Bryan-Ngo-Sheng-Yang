using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int speed = 3;
    int health = 100;
    int hitCounter = 0;

    bool isAlive = true;
    bool onAttack = false;

    public GameObject Cube;
    public Text Health;
    Animator PlayerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == true)
        {
            // Walk Forward
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                PlayerAnimator.SetBool("isStrafe", true);
            }
            // Walk Backward
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                PlayerAnimator.SetBool("isStrafe", true);
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                PlayerAnimator.SetBool("isStrafe", false);
            }
            //Player Move Left
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                PlayerAnimator.SetBool("isStrafe", true);
            }
            //Player Move Right
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                PlayerAnimator.SetBool("isStrafe", true);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                PlayerAnimator.SetBool("isStrafe", false);
            }
            // Attack
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerAnimator.SetTrigger("triggerAttack");
                if (onAttack == true)
                {
                    hitCounter ++;
                    //Debug.Log(hitCounter);
                    if (hitCounter >= 5)
                    {
                        Destroy(Cube);
                    }
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            health -= 10;
            Health.GetComponent<Text>().text = "Health : " + health;
            if (health <= 0)
            {
                PlayerAnimator.SetTrigger("touchBox");
                isAlive = !isAlive;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            onAttack = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            onAttack = false;
        }
    }
}
