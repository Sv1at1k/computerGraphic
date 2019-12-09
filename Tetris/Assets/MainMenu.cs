using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void StartLevel1(){
    SceneManager.LoadScene("TetrisLeve1");

}
public void StartLevel2(){
    SceneManager.LoadScene("TetrisLevel2");

}
public void StartLevel3(){
    SceneManager.LoadScene("TetrisLevel3");

}
public void StartLevel4(){
    SceneManager.LoadScene("TetrisLevel4");

}
}