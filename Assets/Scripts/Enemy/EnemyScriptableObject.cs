using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Enemy Configuration", menuName = "ScriptableObject/Enemy Configuration")]
public class EnemyScriptableObject : ScriptableObject
{
    [Header("Base Config")]
    public int health = 100;

    [Space]

    [Header("Combat Config")]
    public int Damage = 5;
    public float AttackRadius = 1.5f;
    [Tooltip("Cooldown between attacks")]
    public float AttackDelay = 1.5f;
    [Tooltip("Layers this enemy can see")]
    public LayerMask LineOfSightLayers;
    public float detectionRange = 5f;
    public float fieldOfView = 90f;

    [Space]

    [Header("State Machine Config")]
    public EnemyState DefaultState;
    public float idleLocationRadius = 4f;
    public float idleMovespeedMultiplier = 0.5f;

    [Space]

    [Header("Navmesh Config")]
    public float AIUpdateInterval = 0.1f;
    public float Acceleration = 8f;
    public float AngularSpeed = 120;
    public int AreaMask = -1;
    public int AvoidancePriority = 50;
    public float BaseOffset = 0;
    public float Height = 2f;
    public ObstacleAvoidanceType ObstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
    public float Radius = 0.5f;
    public float Speed = 3f;
    public float StoppingDistance = 0.5f;

    public void SetupEnemy(Enemy enemy)
    {
        enemy.agent.acceleration = Acceleration;
        enemy.agent.angularSpeed = AngularSpeed;
        enemy.agent.areaMask = AreaMask;
        enemy.agent.avoidancePriority = AvoidancePriority;
        enemy.agent.baseOffset = BaseOffset;
        enemy.agent.height = Height;
        enemy.agent.radius = Radius;
        enemy.agent.speed = Speed;
        enemy.agent.stoppingDistance = StoppingDistance;

        enemy.movement.DefaultState = DefaultState;
        enemy.movement.IdleLocationRadius = idleLocationRadius;
        enemy.movement.IdleMovespeedMultiplier = idleMovespeedMultiplier;
        enemy.movement.updateSpeed = AIUpdateInterval;

        enemy.movement.lineOfSightChecker.fieldOfView = fieldOfView;
        enemy.movement.lineOfSightChecker.sphereCollider.radius = detectionRange;

        enemy.health = health;

        (enemy.attackRadius.sphereCollider == null ? enemy.attackRadius.GetComponent<SphereCollider>() : enemy.attackRadius.sphereCollider).radius = AttackRadius;
        enemy.attackRadius.attackCooldown = AttackDelay;
        enemy.attackRadius.damage = Damage;
    }
}
