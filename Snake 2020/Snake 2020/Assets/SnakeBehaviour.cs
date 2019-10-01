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
        bool isLeftPressed = Input.GetKey("a");
        bool isRightPressed = Input.GetKey("d");
        bool isAtackPressed = Input.GetKey("space");
       
    
        if(isWalkingPressed || isLeftPressed ||isRightPressed){
                 m_animator.SetBool("isWalking",true);
        }else {

             m_animator.SetBool("isWalking",false);
        }
      
        if (isWalkingPressed)
        {
           
           
        }
        if (isLeftPressed)
        {
           
           
        }
        if (isRightPressed)
        {   
            
            
             
        }
        if (isAtackPressed)
        { m_animator.SetBool("isAtacking",true);

        }else {
              m_animator.SetBool("isAtacking",false);

        }
       
}
}