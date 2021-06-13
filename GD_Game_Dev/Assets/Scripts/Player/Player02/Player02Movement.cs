using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02Movement : MonoBehaviour
{
    public Player02Controller P02Controller;
    public Animator P02Animator;
    private Rigidbody2D m_Rigidbody2D;
     public float  runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
   

   void Start() {
       	m_Rigidbody2D = GetComponent<Rigidbody2D>();
   }
   
    void Update()
    {
        horizontalMove  = Input.GetAxisRaw("Horizontal") * runSpeed;
        P02Animator.SetFloat("Player02Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
               P02Animator.SetBool("P02IsJumping", true);
                jump = true;
          
        }

        if(m_Rigidbody2D.velocity.y < 0){
            P02Animator.SetBool("P02IsFalling", true);
             P02Animator.SetBool("P02IsJumping", false);
        }else{
              P02Animator.SetBool("P02IsFalling", false);
        }
        
    }

    

    void FixedUpdate() {
        P02Controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
         jump = false;
    }

    public void OnLanding(){
         P02Animator.SetBool("P02IsJumping", false);
    }
}
