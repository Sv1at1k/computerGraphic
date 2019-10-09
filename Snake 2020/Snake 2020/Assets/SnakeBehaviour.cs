using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.UI;


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
    int lifes = 2;

    private RawImage heart1, heart2, heart3;

    public Rigidbody rb;

    void OnCollisionEnter(Collision colider)
    {
        var fullname = colider.gameObject.name;
        var name = fullname.Substring(0, 4);

        if (name == "Cube")
        {
            lifes--;
            if (lifes < 1)
            {
                m_animator.SetBool("isDead", true);
                isDead = true;
            }
            Debug.Log(lifes);

        }
        else if (name == "Plan" & lifes < 3)
        {
            Destroy(colider.gameObject);
            lifes++;
            Debug.Log(lifes);
        }
    }

    void Start()
    {   var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();

        heart1 = GameObject.Find("heart1").GetComponent<RawImage>();
        heart2 = GameObject.Find("heart2").GetComponent<RawImage>();
        heart3 = GameObject.Find("heart3").GetComponent<RawImage>();

    }

    void FixedUpdate()
    {
        if (!isDead)
        {

            moveAnimation();
            move();
        }
    }

    void Update(){
        getLifes();

    }

    private void move()
    {   

        Vector3 movement = new Vector3();

        if (isWalkingPressed)
        {
            transform.position += transform.forward * speed;
            rb.MovePosition(transform.position * Time.fixedDeltaTime);
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
    private void getLifes()
    {   
        switch (lifes)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;


        }



    }

}