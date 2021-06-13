using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player03Movement : MonoBehaviour
{
    public Player03Controller P03Controller;
    public Animator P03Animator;
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
        P03Animator.SetFloat("P03Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
               P03Animator.SetBool("P03Isjumping", true);
                jump = true;
          
        }

        if(m_Rigidbody2D.velocity.y < 0){
            P03Animator.SetBool("P03Isjumping", false);
            P03Animator.SetBool("P03Isfalling", true);
        }else{
              P03Animator.SetBool("P03Isfalling", false);
        }
        
    }

    

    void FixedUpdate() {
        P03Controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
         jump = false;
    }

    public void OnLanding(){
         P03Animator.SetBool("P03Isjumping", false);
    }
}
