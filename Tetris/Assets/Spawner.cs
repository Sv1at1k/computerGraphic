using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{  
   public GameObject[] Tetrises;
    void Start()
    {  
        newTetris();
    }


    public void newTetris(){
        Instantiate(Tetrises[Random.Range(0,Tetrises.Length)],transform.position,Quaternion.identity);
    }
}
