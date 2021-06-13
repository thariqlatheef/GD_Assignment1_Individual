using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharactorSwap : MonoBehaviour
{
   
   public GameObject charactor_1;
   public GameObject charactor_2;
   public GameObject Player;

   public Counter Counter;

   public CinemachineVirtualCamera Camera;
   public GameObject playerManager;

   public StaminaBar staminaBar;



   public bool IsCharactorSwaped;
   public bool IsCharactorXSwaped;
   public bool IsCharactorZSwaped;
   public bool IsTransformed;
   public bool Isultimate;
   
   public float timer = 10f;

void Start() {
        Player.SetActive(true);
        charactor_1.SetActive(false);
        charactor_2.SetActive(false);
        IsCharactorSwaped = false;
        IsCharactorXSwaped = false;
        IsCharactorZSwaped = false;
        Isultimate = false;
        IsTransformed = false;
        staminaBar.SetStamina(timer);
        
}

    
    void Update()
    {
            
             if(!IsCharactorSwaped){
                 if(Counter.GetGateCount() == 1){
                    if(Input.GetButtonDown("Z") && !IsCharactorZSwaped){
                        SetDeActive(charactor_2);
                        SwapPlayer(charactor_1,Player);
                      
                        IsCharactorZSwaped = true; 
                    }
                 }
 
            }else{

                if(!Isultimate){
                     if(Counter.GetGateCount() == 1){
                           if(Input.GetButtonDown("Z") && IsCharactorZSwaped ){
                        SetDeActive(charactor_2);
                        SwapBack(Player,charactor_1);
                        IsCharactorZSwaped = false;
                        IsTransformed = false;
                           }
                    }
                     if(Counter.GetGateCount() == 2){
                           if(Input.GetButtonDown("X") && !IsCharactorXSwaped && IsCharactorZSwaped){
                                SwapPlayer(charactor_2,charactor_1);
                                IsTransformed = true;
                                IsCharactorXSwaped = true;
                                Isultimate = true;
                                Debug.Log("Ultimate Attack");
                        }
                     }

                }

         
                  
            }

    if(IsTransformed){
        StartTimer();
    }else{
          CountUp();
    }


    }


     private void StartTimer ( ){
          staminaBar.SetStamina(timer);
           timer -= Time.deltaTime;
          
            // Debug.Log(timer);
                    if (timer<0)
                    {  
                        if(IsCharactorXSwaped){
                        //    SetDeActive(charactor_1);
                            SwapBack(charactor_1,charactor_2);
                            
                             IsCharactorZSwaped = true;
                            Isultimate = false;
                            IsTransformed = false;
                            IsCharactorSwaped = true;
                            CountUp();
                     }
                         
                    }
                
            
    }


    private void CountUp(){
        staminaBar.SetStamina(timer);
             timer += Time.deltaTime;
             
             if(timer >= 10f){
                 IsCharactorXSwaped = false;
                    timer = 10f;
                    // Debug.Log("Counting up");
             }
             
    }
    private void SwapPlayer(GameObject Player, GameObject Charactor){

                    Charactor.SetActive(false);
                    
                    Player.transform.position = Charactor.transform.position;
                    Player.transform.rotation = Charactor.transform.rotation;
                //     Player.transform.localScale = Charactor.transform.localScale;
                    
                    Camera.Follow = Player.transform;
                    Player.SetActive(true);
                    IsCharactorSwaped = true;

    }


     private void SwapBack(GameObject Player, GameObject Charactor){

                    Charactor.SetActive(false);
                    Player.transform.position = Charactor.transform.position;
                    Player.transform.rotation = Charactor.transform.rotation;
                //     Player.transform.localScale = Charactor.transform.localScale;
                    Camera.Follow = Player.transform;
                    Player.SetActive(true);
                    IsCharactorSwaped = false;

    }

    private void SetActive(GameObject Char){
                Char.SetActive(true);
    }
    private void SetDeActive(GameObject Char){
                Char.SetActive(false);
    }

    public void RespawnPlayer(Vector3 posi){

        charactor_1.transform.position = posi;
        charactor_2.transform.position= posi;
        Player.transform.position= posi;

    }


}
