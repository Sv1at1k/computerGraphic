using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;


public class SnakeBehaviour : MonoBehaviour
{

    Animator m_animator;
    public float movementSpeed = 20.0f;
    public float rotSpeed = 45.0f;
    public float speed = 0;

    private float moveSpeed = 1;
    void Start()
    {
        m_animator = GetComponent<Animator>();

    }

    void Update()
    {






        move();
        moveAnimation();




    }
    private void move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0);
        }

    }
    private void moveAnimation()
    {
        bool isWalkingPressed = Input.GetKey("w");
        bool isLeftPressed = Input.GetKey("a");
        bool isRightPressed = Input.GetKey("d");
        bool isAtackPressed = Input.GetKey("space");


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

}