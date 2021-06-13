using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01Movement : MonoBehaviour
{

    private Rigidbody2D m_Rigidbody2D;
    public Player01Controller P01Controller;
    public Animator P01Animator;
     public float  runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
   
    void Start() {
       	m_Rigidbody2D = GetComponent<Rigidbody2D>();
   }
    void Update()
    {
        horizontalMove  = Input.GetAxisRaw("Horizontal") * runSpeed;
        P01Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
               P01Animator.SetBool("IsJumping", true);
                jump = true;
          
        }

        if(m_Rigidbody2D.velocity.y < 0){
            P01Animator.SetBool("IsFalling", true);
             P01Animator.SetBool("IsJumping", false);
        }else{
              P01Animator.SetBool("IsFalling", false);
        }
        
    }

    void FixedUpdate() {
        P01Controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
         jump = false;
    }

    public void OnLanding(){
         P01Animator.SetBool("IsJumping", false);
    }
}
