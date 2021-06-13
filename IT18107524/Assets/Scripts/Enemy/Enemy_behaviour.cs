using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour : MonoBehaviour
{

    #region Public Variables
    public float attackDistance; //Minimum distance for attack  
    public float moveSpeed;
    public float timer; //Timer for cooldown between attacks
    public Transform leftLimit;
    public Transform rightLimit;
    public GameObject hitbox;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange; //Check if Player is in range
    public GameObject hotZone;
    public GameObject triggerArea;



    #endregion

    #region Private Variables
    private Animator anim;
    private float distance; //Store the distance b/w enemy and player
    private bool attackMode;
    private bool cooling; //Check if Enemy is cooling after attack
    private float intTimer;
    #endregion

    void Awake()
    {
        SelectTarget();
        intTimer = timer; //Store the inital value of timer
        anim = GetComponent<Animator>();
        hitbox.SetActive(false);
    }

    void Update()
    {
        if (!attackMode)
        {
            Move();
        }

        if (!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            SelectTarget();// to go back to enemy patroling area
        }

        if (inRange)
        {
            EnemyLogic();//when need to attack
        }
    }
    void EnemyLogic() //to check attack or stop attack or in cooldown
    {
        distance = Vector2.Distance(transform.position, target.position); //calc distcance between enemy and payer

        if (distance > attackDistance) //too much distance
        {
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false) //can attack and not in cooling state
        {
            Attack();
        }

        if (cooling) //in cooling state
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }//

    void Move()//move if enemy notin attack mode
    {
        anim.SetBool("canWalk", true); //can walk while move state

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack")) // dont run this while attack
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); // move from enemy position to player position
        }
    }//moving 

    void Attack()//if the player in attack range and enemy not in cooling mode
    {
        timer = intTimer; //Reset Timer when Player enter Attack Range
        attackMode = true; //To check if Enemy can still attack or not ///// now he cantmove

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true); //play the attack animation
        hitbox.SetActive(true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }//create a timer and can see at imspector

    void StopAttack() //if the distnce is too much to attack
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
        hitbox.SetActive(false);
    }

    public void TriggerCooling() //public funtion to access with other script
    {
        cooling = true;
    }

    private bool InsideOfLimits() //to check enemy is exactly in the right and left caps
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget() //select left or right cap targets to go again to the patroling
    {
        float distanceToLeft = Vector3.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector3.Distance(transform.position, rightLimit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;// walt to the left target
        }
        else
        {
            target = rightLimit;
        }

        //Ternary Operator
        //target = distanceToLeft > distanceToRight ? leftLimit : rightLimit;

        Flip(); // to check need to flipor not
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180;
        }
        else
        {
            rotation.y = 0;
        }

        //Ternary Operator
        //rotation.y = (currentTarget.position.x < transform.position.x) ? rotation.y = 180f : rotation.y = 0f;

        transform.eulerAngles = rotation;
    }

    public void Hurt()
    {
        //hurt animation
        anim.SetTrigger("hurt");

        Debug.Log("In hurt function");
    }

    public void die()
    {
        //die animation and disable and destroy the enemy sprite
        anim.SetBool("isDead", true);
        Debug.Log("In die function");

        if(GetComponent<Collider2D>() == null){
            return;
        }
        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;

    }

    public void enemyDestry()
    {
        Destroy(this.gameObject);

        anim.SetBool("Attack", false);
        anim.SetBool("canWalk", false);
    }
}
