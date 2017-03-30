using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    /*
     *  Private = Not accesable through other scripts (Will not be shown in the inspector)
     *  Public = Accesable through other scripts (Will be shown in the inspector)
     *  protected = Only accesable through scripts that use Inheritance (Will not be shown in the inspector)
     *  [SerializeField] Private = Not accesable through other scripts but lets you see the variable in the inspector 
     */
    
    private Animator anim;

    //protected float distance;
    
    public float attackRange, chaseRange;

    [SerializeField] private Transform target;

    private EnemyHealth enemyHealth;

    public void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        //Debug.Log("EM awake");
        anim = GetComponent<Animator>();
    }

    protected virtual void Yell()
    {
        //Debug.Log("EnemyManager is Active");
    }

    protected void Idle(string idle)
    {
        anim.Play(idle);
        //Debug.Log("I'm Standing Idle");
    }

    protected void Walk(string walk)
    {  
        anim.Play(walk);
        //Debug.Log("I'm Walking");
    }

    protected void Run(string run)
    { 
        anim.Play(run);
        //Debug.Log("I'm Running");
    }

    protected void Attack(string attack)
    {
        anim.Play(attack);
       // Debug.Log("Attack!!");
    }

    protected void Skill(string skill)
    {
        anim.Play(skill);
        //Debug.Log("I'm Powering-Up");
    }

    public void Death(string death)
    {
        anim.Play(death);
       // Debug.Log("Death :(");
    }

    public float CheckDistance()
    {
        float distance;
        distance = Vector3.Distance(target.position, transform.position);
        return distance;
    }

    public void LookAtTarget()
    {
        Vector3 lookAt = target.position;
        lookAt.y = transform.position.y;
        transform.LookAt(lookAt);
    }

    public virtual void Destroy()
    {

    }

    public void ReadyToDestroy()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Sword")
        {
            //Debug.Log("Weapon tracked");
            enemyHealth.curHp -= 10;
            //Debug.Log("Hp: " + enemyHealth.curHp);
        }
        if(other.gameObject.tag == "FireSword")
        {
            enemyHealth.curHp -= 20;
        }
    }

}
