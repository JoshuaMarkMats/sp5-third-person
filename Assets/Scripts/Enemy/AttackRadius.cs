using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AttackRadius : MonoBehaviour
{
    protected List<IDamageable> Damageables = new List<IDamageable>();
    public int damage = 10;
    public float attackCooldown = 0.5f;
    public delegate void AttackEvent(IDamageable Target);
    public AttackEvent onAttack;
    public SphereCollider sphereCollider;
    protected Coroutine attackCoroutine;

    private IDamageable targetClosestDamageable;

    //damageables that enter range added to list; start attacking
    protected virtual void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            if (damageable.IsAlive)
            {
                Damageables.Add(damageable);
                attackCoroutine ??= StartCoroutine(StartAttack());
            }           
        }
    }

    //damageables that exit range added to list, stop attacking
    protected virtual void OnTriggerExit(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Damageables.Remove(damageable);
            if (Damageables.Count == 0)
            {
                attackCoroutine = null;
            }
        }
    }

    //attack closest damageable, this is looped until no damageables are in range
    protected virtual IEnumerator StartAttack()
    {
        WaitForSeconds wait = new(attackCooldown);

        yield return wait;

        IDamageable closestDamageable = null;

        //get distance of each damageable, save closest
        while (Damageables.Count > 0)
        {
            closestDamageable = GetClosestDamageable();

            if (closestDamageable != null)
            {
                onAttack?.Invoke(closestDamageable);
                targetClosestDamageable = closestDamageable;
                closestDamageable.TakeDamage(damage);
            }

            yield return wait;

            //clear out disabled damageables for safety(?)
            Damageables.RemoveAll(DisableDamageables);
        }

        attackCoroutine = null;      
    }

    //was supposed to be for delayed attack but oh well lacking time
    /*public void Attack()
    {
        if (Vector3.Distance(transform.position, targetClosestDamageable.GetTransform().position) < sphereCollider.radius)
        {
            Debug.Log($"{gameObject.name} is attacking {targetClosestDamageable}");
            targetClosestDamageable.TakeDamage(damage);
        }
            
    }*/

    private IDamageable GetClosestDamageable()
    {
        IDamageable closestDamageable = null;
        float closestDistance = float.MaxValue; //initialize to max possible range

        for (int i = 0; i < Damageables.Count; i++)
        {
            Transform damageableTransform = Damageables[i].GetTransform();
            float distance = Vector3.Distance(transform.position, damageableTransform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestDamageable = Damageables[i];
            }
        }

        return closestDamageable;
    }

    protected bool DisableDamageables(IDamageable Damageable)
    {
        return Damageable != null && !Damageable.GetTransform().gameObject.activeSelf;
    }

    public void SetAttackRadius(float attackRadius) { 
        gameObject.GetComponent<SphereCollider>().radius = attackRadius;
    }
}
