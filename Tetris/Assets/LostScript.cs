using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LostScript : MonoBehaviour
{   public static bool isLost = false;
    Text lost;
    void Start()
    {
        lost = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLost){
            lost.text = "You lost with score:" + ScoreScript.value +" Press W to continue";
            

        }
    }
}
