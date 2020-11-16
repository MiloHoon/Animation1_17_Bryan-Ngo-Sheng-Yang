using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 3;

    Animator PlayerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Walk Forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            PlayerAnimator.SetBool("isStrafe", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            PlayerAnimator.SetBool("isStrafe", false);
        }

        // Walk Backward
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
            PlayerAnimator.SetBool("isStrafe", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerAnimator.SetBool("isStrafe", false);
        }

        // Attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAnimator.SetTrigger("triggerAttack");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            PlayerAnimator.SetTrigger("touchBox");
        }
    }
}
