using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;


public class SnakeBehaviour : MonoBehaviour
{
    Animator m_animator;


    private bool isGameOver;
    private bool isDead;
    bool isWalkingPressed;
    bool isLeftPressed;
    bool isRightPressed;
    bool isAtackPressed;

    float speed = 1;

    public Rigidbody rb;

    //  void OnCollisionEnter(Collision collisionInfo)
    // {
    //     if (collisionInfo.gameObject.name == "Walls")
    //     {    Time.timeScale = 0;
    //          isDead = true;

    //     }else {

    //         isDead = false;
    //     }
    // }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        // float moveHoriontal = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");
        // Vector3 movement = new Vector3(moveHoriontal, 0, moveVertical);
        // rb.AddForce(movement * speed);
        moveAnimation();
        move();
    }

    private void move()
    {

        Vector3 movement = new Vector3();

        if (isWalkingPressed)
        {
           // movement = new Vector3(0, 0, 10);
            transform.position += transform.forward * speed;
            rb.MovePosition(transform.position  * Time.fixedDeltaTime);


        }

        if (isRightPressed)
        {
            movement = new Vector3(0, 79, 0);
            Quaternion deltaRotation = Quaternion.Euler(movement * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        if (isLeftPressed)
        {
            movement = new Vector3(0, -79, 0);
            Quaternion deltaRotation = Quaternion.Euler(movement * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

    }
    private void moveAnimation()
    {
        isWalkingPressed = Input.GetKey("w");
        isLeftPressed = Input.GetKey("a");
        isRightPressed = Input.GetKey("d");
        isAtackPressed = Input.GetKey("space");


        if (isWalkingPressed || isLeftPressed || isRightPressed)
        {
            m_animator.SetBool("isWalking", true);
        }
        else
        {
            m_animator.SetBool("isWalking", false);
        }
        if (isAtackPressed)
        {
            m_animator.SetBool("isAtacking", true);

        }
        else
        {
            m_animator.SetBool("isAtacking", false);

        }



    }

    private void endGame()
    {



    }

}