using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P02Attack : MonoBehaviour
{
    public Animator Animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attack01DamageAmount = 20f;
    public float attackRate = 2f;
    public float attackRange = 0.5f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void PlayerAttack()
    {
        Animator.SetTrigger("P02Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamge(attack01DamageAmount);
            //   Debug.Log (enemy.name);
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
