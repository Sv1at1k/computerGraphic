using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{       Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalkingPressed = Input.GetKey("w");
        m_animator.SetBool("isWalking",isWalkingPressed);

         bool isAtackPressed = Input.GetKey("space");
        m_animator.SetBool("isAtacking",isAtackPressed);
}
}