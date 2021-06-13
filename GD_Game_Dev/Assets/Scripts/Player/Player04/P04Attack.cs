using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P04Attack : MonoBehaviour
{
    public Animator Animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    public float attackRange = 0.5f;
    public float attack01DamageAmount = 30f;
    public float attack02DamageAmount = 15f;
    public float attack03DamageAmount = 15f;
    float nextAttackTime = 0f;



    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetMouseButtonDown(0))
            {
                PlayerAttack01();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            //  if(Input.GetMouseButtonDown(1)){
            //         PlayerAttack02();
            //         nextAttackTime = Time.time + 1f / attackRate;
            //  }

            // if(Input.GetButtonDown("F")){
            //        PlayerAttack03();
            //         nextAttackTime = Time.time + 1f / attackRate;

            // }

        }

    }

    void PlayerAttack01()
    {
        Animator.SetTrigger("P04Attack01");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamge(attack01DamageAmount);
            //   Debug.Log (enemy.name);

        }
    }

    void PlayerAttack02()
    {
        Animator.SetTrigger("P04Attack02");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
        }
    }


    void PlayerAttack03()
    {
        Animator.SetTrigger("P04Attack03");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void SetDamage(float Damage)
    {
        attack01DamageAmount = Damage;
    }
}
