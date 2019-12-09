using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class wonScript : MonoBehaviour
{ public static bool isWon = false;
    Text won;
    void Start()
    {
        won = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWon){
            won.text = "You WON CONGRATS: Press W to continue";
            

        }
    }
}
