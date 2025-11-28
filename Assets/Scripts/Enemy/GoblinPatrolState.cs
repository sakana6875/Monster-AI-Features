using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPatrolState : BaseState
{
    private Vector2 startPos;
    private bool movingRight = true;

    public GoblinPatrolState(Enemy enemy) : base(enemy) { }

    public override void OnEnter()
    {
        startPos = enemy.transform.position;
    }

    public override void LogicUpdate()
    {
        float distanceFormStart = Vector2.Distance(enemy.transform.position, startPos);
        if (distanceFormStart > enemy.EnemyData.patrol.patrolRange)
        {
            movingRight = !movingRight;
        }

        float sight = enemy.EnemyData.chase.sightDistance;
        if (Vector2.Distance(enemy.transform.position, PlayerManager.Instance.transform.position) < sight)
        {
            enemy.SwitchState(StateFactory.CreateChaseState(enemy.EnemyType, enemy));
        }
    }

    public override void PhysicsUpdate()
    {
        float speed = enemy.EnemyData.patrol.moveSpeed;
        Vector2 dir = movingRight ? Vector2.right : Vector2.left;
        enemy.Move(dir * speed);
    }

}
