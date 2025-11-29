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
        float directionX = Mathf.Sign(PlayerManager.Instance.transform.position.x - enemy.transform.position.x);
        float speed = enemy.EnemyData.chase.chaseSpeed;
        enemy.Move(directionX * speed);
        FlipTowardsPlayer();
    }

    private void FlipTowardsPlayer()
    {
        float playerX = PlayerManager.Instance.transform.position.x;
        float enemyX = enemy.transform.position.x;

        if (playerX > enemyX)
        {
            enemy.transform.localScale = new Vector3 (1, 1, 1);
        }
        else if (playerX < enemyX)
        {
            enemy.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
