using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float Maxhelth = 100f;
    public float currentHelth = 0;
    private Enemy_behaviour enemy_Behaviour;
    void Start()
    {
        currentHelth = Maxhelth;
        enemy_Behaviour = FindObjectOfType<Enemy_behaviour>();
    }


    void Update()
    {

    }

    public void TakeDamge(float dmage)
    {

        if (currentHelth < 0.01f)
        {
            Debug.Log("Enemy Died");
            //die animation and disable and destroy the enemy sprite
            //enemy_behaviour.die();
            FindObjectOfType<Enemy_behaviour>().die();
        }
        else
        {
            currentHelth -= dmage;
            Debug.Log("Take Damage Amount :" + dmage);
            //hurt animation
            FindObjectOfType<Enemy_behaviour>().Hurt();
        }
    }
}
