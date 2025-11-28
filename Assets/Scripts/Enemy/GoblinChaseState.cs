using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GoblinChaseState : BaseState
{
    public GoblinChaseState(Enemy enemy) : base(enemy) { }

    public override void LogicUpdate()
    {
        Vector2 toPlayer = (PlayerManager.Instance.transform.position - enemy.transform.position).normalized;
        float dist = Vector2.Distance(enemy.transform.position, PlayerManager.Instance.transform.position);

        if (dist > enemy.EnemyData.chase.loseSightDistance)
        {
            enemy.SwitchState(StateFactory.CreateInitialState(enemy.EnemyType, enemy));
        }
    }

    public override void PhysicsUpdate()
    {
        Vector2 toPlayer = (PlayerManager.Instance.transform.position - enemy.transform.position).normalized;
        float speed = enemy.EnemyData.chase.chaseSpeed;
        enemy.Move(toPlayer * speed);
    }
}
