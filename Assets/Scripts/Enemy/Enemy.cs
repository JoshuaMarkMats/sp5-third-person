using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    public AttackRadius attackRadius;
    public Animator animator;
    public EnemyController movement;
    public NavMeshAgent agent;
    public EnemyScriptableObject enemyStats;
    public int health = 100;

    [SerializeField]
    private float deathDuration = 3;
    public bool isAlive = true;

    private Coroutine lookCoroutine, stayStillCoroutine, deathCoroutine;
    private const string ATTACK_TRIGGER = "Attack", DEATH_TRIGGER = "ToggleDeath";

    private void Awake()
    {
        attackRadius.onAttack += OnAttack;
    }

    private void Update()
    {
        if (isAlive && health <= 0)
        {
            deathCoroutine = StartCoroutine(Death(deathDuration));
        }
    }

    public bool IsAlive { get { return isAlive; } }

    private void OnAttack(IDamageable Target)
    {
        if (isAlive)
        {
            animator.SetTrigger(ATTACK_TRIGGER);

            stayStillCoroutine = StartCoroutine(StayStill(attackRadius.attackCooldown));

            if (lookCoroutine != null)
            {
                StopCoroutine(lookCoroutine);
            }

            lookCoroutine = StartCoroutine(LookAt(Target.GetTransform()));
        }
    }

    private IEnumerator LookAt(Transform Target)
    {
        if (isAlive)
        {
            Quaternion lookRotation = Quaternion.LookRotation(Target.position - transform.position);
            float time = 0;

            while (time < 1)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);

                time += Time.deltaTime * 2;
                yield return null;
            }

            transform.rotation = lookRotation;
        }
    }
    
    //stay still while attacking
    private IEnumerator StayStill(float duration)
    {
        agent.isStopped= true;
        yield return new WaitForSeconds(duration);
        if (agent.enabled)
            agent.isStopped = false;

    }

    public virtual void OnEnable()
    {
        enemyStats.SetupEnemy(this);
    }

    public void TakeDamage(int Damage)
    {
        if (health > Damage)
        {
            health -= Damage;
        }
        else
        {
            health = 0;
        }
            
    }

    public Transform GetTransform()
    {
        return transform;
    }

    //allow time for death before thanos sna
    private IEnumerator Death(float duration)
    {
        isAlive = false;
        if (stayStillCoroutine != null)
        {
            StopCoroutine(stayStillCoroutine);
        }
        agent.enabled = false;
        animator.SetTrigger(DEATH_TRIGGER);
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
