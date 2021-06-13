using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
      public float attackDamage = 10f; 
         private void OnTriggerEnter2D(Collider2D other) {
         if(other.transform.tag == "Player"){
            other.GetComponentInParent<PlayerHelth>().TakeDamage(attackDamage);
            other.GetComponentInChildren<Animator>().SetTrigger("hit");
            
         }
    }
}
