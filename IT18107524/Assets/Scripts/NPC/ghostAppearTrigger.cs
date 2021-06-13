using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostAppearTrigger : MonoBehaviour
{
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.transform.tag == "Player")
        {
            anim.Play("appear");
            Debug.Log("Player Enterd 123");
            Destroy(this.gameObject);
        }
    }
}
