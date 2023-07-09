using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : GroundedPaperSprite
{
    public float attackRange = 5;
    public bool isAttacking = false;
    public bool isDead = false;
    public bool isMelee = true;
    public bool followPlayer = true;
    
    private Stats stats;
    private AttackMake attack;
    private Transform target;
    private Rigidbody rb3D;
    private float scaleX;

    public override void Start()
    {
        attack = this.GetComponentInChildren<AttackMake>();
        base.Start();
        rb3D = GetComponent<Rigidbody>();
        scaleX = gameObject.transform.localScale.x;

        if ((GameObject.FindGameObjectWithTag("Player") != null) && (followPlayer == true)) {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            
        } else {
            target = transform;
        }

        stats = this.GetComponent<Stats>();
    }

    public override void Update()
    {
        checkIfDead();
        if (!isDead) {
            float DistToPlayer = Vector3.Distance(transform.position, target.position);

            if ((target != null) && (DistToPlayer <= attackRange)) {
                requestedMovement = (target.position - transform.position).normalized * stats.speed * Time.deltaTime;

                animator.SetBool("IsWalking", true);
                if (isMelee) {
                    attack.MeleeAttackEnemy(stats.damage);
                } else {
                    attack.RangedAttackEnemey(stats.damage);
                }

            } else {
                requestedMovement = Vector3.zero;
                animator.SetBool("IsWalking", false);
            }
        } 

        base.Update();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            isAttacking = true;
            // Debug.Log("Player enter enemy attack range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            isAttacking = false;
            // Debug.Log("Player leave enemy attack range");
        }
    }


    public void checkIfDead()
    {
        if (stats.hp <= 0)
        {
            if (!isDead)
            {
                // Debug.Log("Enemy dead");

                animator.SetTrigger("IsDead");
                isDead = true;
                Destroy(gameObject);
            }
        }
    }


    //DISPLAY the range of enemy's attack when selected in the Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

