using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : EnemyManager
{
    private Transform myTransform;
    [SerializeField] private float moveSpeed;

    private EnemyHealth health;

    private void Start()
    {
        health = GetComponent<EnemyHealth>();
        myTransform = this.transform;
    }

    private void Update()
    {
        //If the distance is between 8 and 2, play animation
        if (CheckDistance() < chaseRange && CheckDistance() > attackRange)
        {
            LookAtTarget();
            Walk("Walk");
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
        //If the distance is smaller then 2, play animation
        else if (CheckDistance() < attackRange)
        {
            LookAtTarget();
            Attack("Attack");
        }
        else if (health.curHp == 0) //if health smaller or equal is to zero, play the Death animation
        {
            //DOENS'T WORK !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Death("Death");
        }
        else if(CheckDistance() > chaseRange) //Else play idle animation
        {
            Idle("Idle");
        }  
           
    }
    
}
