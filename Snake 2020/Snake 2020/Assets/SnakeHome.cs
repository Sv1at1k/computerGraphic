using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHome : MonoBehaviour
{
      void OnCollisionEnter(Collision colider)
    {
        var fullname =colider.gameObject.name;
              
        if (name == "Znake")
        {  Debug.Log("+1");
          
            //m_animator.SetBool("isDead", true);
           //   isDead = true;

        }
    }
}
