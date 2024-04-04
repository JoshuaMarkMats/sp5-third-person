using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class EnemyLineOfSightChecker : MonoBehaviour
{
    public SphereCollider sphereCollider;
    public float fieldOfView = 90f;
    public LayerMask lineOfSightLayers;

    public delegate void GainSightEvent(Player player);
    public GainSightEvent onGainSight;
    public delegate void LoseSightEvent(Player player);
    public LoseSightEvent onLoseSight;

    private Coroutine checkForLineOfSightCoroutine;

    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("player entered");
        if (other.TryGetComponent(out Player player))
        {

            if (!CheckLineOfSight(player))
            {
                checkForLineOfSightCoroutine = StartCoroutine(CheckForLineOfSight(player));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            onLoseSight?.Invoke(player);
            if (checkForLineOfSightCoroutine != null)
                StopCoroutine(checkForLineOfSightCoroutine);
        }
    }

    private bool CheckLineOfSight(Player player)
    {
        Vector3 vectorToPlayer = player.transform.position - transform.position;
        Vector3 direction = vectorToPlayer.normalized;
        if (Vector3.Dot(transform.forward, direction) >= Mathf.Cos(fieldOfView))
        {
            if (player.IsCrouching && Vector3.SqrMagnitude(vectorToPlayer) > (sphereCollider.radius * sphereCollider.radius) / 3)
                return false;
            onGainSight?.Invoke(player);
        }
        return false;
    }

    private IEnumerator CheckForLineOfSight(Player player)
    {
        WaitForSeconds wait = new(0.1f);

        while (!CheckLineOfSight(player))
        {
            yield return wait;
        }
    }
}