using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hound : EnemyManager
{
    private Transform myTransform;
    [SerializeField]
    private float moveSpeed;

    private EnemyHealth health;

    private void Start()
    {
        health = GetComponent<EnemyHealth>();
        myTransform = this.transform;
    }

    private void Update()
    {

        //CheckDistance();

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
        //if health smaller or equal is to zero, go to destroy function
        else if (health.curHp <= 0)
        {
            Death("Death");
        }
    }

}
