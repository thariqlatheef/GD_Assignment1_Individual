using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player04Movement : MonoBehaviour
{
    public Player04Controller P04Controller;
    public Animator P04Animator;
    private Rigidbody2D m_Rigidbody2D;
     public float  runSpeed = 40f;
    float horizontalMove = 0f;
    // bool jump = false;
   

   void Start() {
       	m_Rigidbody2D = GetComponent<Rigidbody2D>();
   }
   
    void Update()
    {
        horizontalMove  = Input.GetAxisRaw("Horizontal") * runSpeed;
        P04Animator.SetFloat("P04Speed", Mathf.Abs(horizontalMove));

      
        if(m_Rigidbody2D.velocity.y < 0){
         
            // P04Animator.SetBool("P03Isfalling", true);
        }else{
             
        }
        
    }

    

    void FixedUpdate() {
        P04Controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        //  jump = false;
    }

}
