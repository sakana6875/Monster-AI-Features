using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private EnemyData enemyData;

    private Rigidbody2D rb;
    private BaseState currentState;

    public EnemyType EnemyType => enemyType;
    public EnemyData EnemyData => enemyData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentState?.LogicUpdate();
    }

    private void FixedUpdate()
    {
        currentState?.PhysicsUpdate();
    }

    public void SwitchState(BaseState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        currentState?.OnEnter();
    }

    public void Move(Vector2 velocity)
    {
        if (rb != null)
            rb.velocity = velocity;
    }

    public EnemyData.PatrolParams GetPatrolParams() => enemyData.patrol;
    public EnemyData.ChaseParams GetChaseParams() => enemyData.chase;
    public EnemyData.AttackParams AttackParams() => enemyData.attack;
}
