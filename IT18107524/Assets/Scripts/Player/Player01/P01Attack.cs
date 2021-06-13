using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P01Attack : MonoBehaviour
{
   public Animator Animator;
   public float attackRate = 2f;
   float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {
if(Time.time >= nextAttackTime){
if(Input.GetMouseButtonDown(0)){
            PlayerAttack();
            nextAttackTime = Time.time + 1f / attackRate;
     }
}   
    
  
    }

    void PlayerAttack(){
            Animator.SetTrigger("P01Attack");
    }
}
