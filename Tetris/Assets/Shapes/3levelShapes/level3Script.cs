using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class level3Script : MonoBehaviour{
    bool isLost = false;
    float previousFallingTime;
    float fallingTime = 0.8f;
    float fastFallingTime = 2f;

     static int height = 25;
     static int width =25;
     int target = 250;
     static Transform[,] grid = new Transform[height,width];
      Text endGame;
    void Update()
    {   
        move();
        fall();
    }
  private void move(){
    if(Input.GetKeyDown(KeyCode.LeftArrow)){
        moveChildrens(new Vector3(-1,0,0));
        if(!validMove()){
             moveChildrens(new Vector3(1,0,0));
        }
        } else if(Input.GetKeyDown(KeyCode.RightArrow)){         
         moveChildrens(new Vector3(1,0,0));
            if(!validMove()){
                 moveChildrens(new Vector3(-1,0,0));
            }
        }else if(Input.GetKeyDown(KeyCode.UpArrow)){
            rotateAroundCenter(90);
          if(!validMove()){
            rotateAroundCenter(-90);
            }
    }
  }  
    private  void fall(){
         
         if(Input.GetKeyDown(KeyCode.DownArrow)){
             moveDown(10);  
         }else 
         {
             moveDown(1);    
         }   
          
    }
    private void moveDown(int speed){
     if(Time.time-previousFallingTime >fallingTime / speed ){
         moveChildrens(new Vector3(0,-1,0));
        previousFallingTime = Time.time;
            if(!validMove()){
                moveChildrens(new Vector3(0,1,0));
                 addToGrid();
                 checkFullLines();
                 this.enabled = false;
                 if(!isLost){
                 FindObjectOfType<Spawner>().newTetris();
                 }
            }
        }
    }

    bool validMove(){
     foreach (Transform children in transform){
        int roundedX = Mathf.RoundToInt(children.transform.position.x);
        int roundedY = Mathf.RoundToInt(children.transform.position.y);
          if( roundedY <= 0 ||roundedX<=10 || roundedX>=20  ){        
             return false; 
         }   
          if(grid[roundedX,Math.Abs(roundedY)] != null){
             return false; 
         }      
    }
      return true;
}
    void moveChildrens(Vector3 newPosition){
       foreach (Transform child in transform){ 
            child.position += newPosition; 
         }
     }

     //2 hours of life wasted on 5 lines of code FUCKKK
     void rotateAroundCenter(int degree){
    foreach (Transform child in transform){
            if(child.name == "center"){
                transform.RotateAround(child.position, new Vector3(0, 0, 1), degree);
            }
        } 
     }
     void addToGrid(){
            foreach (Transform child in transform){
            int roundedX = Mathf.RoundToInt(child.transform.position.x);
            int roundedY = Mathf.RoundToInt(child.transform.position.y);
            grid[roundedX,Math.Abs(roundedY)] = child;
            checkIfLost();
        } 
     }

      void  checkFullLines(){
         for(int i = 0;i<height;i++){
             if(hasLine(i)){
                 updateScore();
                 checkIfWin();
                  checkIfLost();
                 deleteLine(i);
                 rowDown(i);
                 i--;            
               
             }
         }
      }
      bool hasLine(int i){
          int count = 0;
          for(int j = 0; j<width;j++){
              if(grid[j,i] != null){
                 count++;
              }
          }
          if(count == 9){
                 return true;
             }
        return false;
      }
      void deleteLine(int i){
            
             for(int j = 0; j<width;j++){
                if(grid[j,i] != null){
                    Destroy(grid[j,i].gameObject);
                    grid[j,i] = null;
                }
                
      }
}   
     void rowDown(int i){
         for(int j = i;j<height-1;j++){
           for(int k = 0; k<width;k++){
               if(grid[k,j+1] !=null){
                   grid[k,j] = grid[k,j+1];
                   grid[k,j+1] = null;
                   grid[k,j].transform.position -= new Vector3(0,1,0);

               }
            }
         } 
     }

    void updateScore(){
        ScoreScript.value +=10;
    }


   void checkIfWin(){
        if(ScoreScript.value >= target){
            Debug.Log("You won");
        }
    }

    void checkIfLost(){
          for(int j = 0; j<width;j++){
              if(grid[j,20] != null){
               
               LostScript.isLost = true;
                if(Input.GetKey("w")){
                Debug.Log("WWWWW");
                SceneManager.LoadScene("MENU");
                }
              // isLost = true;
              }
          }

     }
 
}   