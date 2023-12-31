using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementOld : MonoBehaviour
{
    
    public Animator anim;
    public Rigidbody rb3D;
    public bool followPlayer = true;
    private Transform target;
    public int damage = 10;

    //public int EnemyLives = 3;
    //private GameHandler gameHandler;

    public float attackRange = 5;
    public bool isAttacking = false;
    //private float scaleX;

    public Stats stats;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb3D = GetComponent<Rigidbody>();
        //scaleX = gameObject.transform.localScale.x;

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        stats = this.GetComponent<Stats>();

        //if (GameObject.FindWithTag("GameHandler") != null)
        //{
        //    gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        //}
    }

    void Update()
    {
        float DistToPlayer = Vector3.Distance(transform.position, target.position);

        if ((target != null) && (DistToPlayer <= attackRange))
        {
            //Ethan see here
            transform.position = Vector3.MoveTowards(transform.position, target.position, stats.speed * Time.deltaTime);

            //anim.SetBool("Walk", true);
            //flip enemy to face player direction. Wrong direction? Swap the * -1.
            //if (target.position.x > gameObject.transform.position.x)
            //{
            //    gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
            //}
            //else
            //{
            //    gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
            //}
        }
        //else { anim.SetBool("Walk", false);}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAttacking = true;
            Debug.Log("Player enter enemy attack range");
            //anim.SetBool("Attack", true);
            //gameHandler.playerGetHit(damage);
            //TODO attack
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAttacking = false;
            Debug.Log("Player leave enemy attack range");
            //anim.SetBool("Attack", false);
        }
    }

    public bool isEnemyDead()
    {
        return (stats.hp <= 0);
    }

    //DISPLAY the range of enemy's attack when selected in the Editor
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

