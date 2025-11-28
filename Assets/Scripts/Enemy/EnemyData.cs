using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Enemy Data", fileName = "NewEnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Ñ²Âß")]
    public PatrolParams patrol = new PatrolParams();

    [Header("×·»÷")]
    public ChaseParams chase = new ChaseParams();

    [Header("¹¥»÷")]
    public AttackParams attack = new AttackParams(); 

    [System.Serializable]
    public class PatrolParams
    {
        public float moveSpeed = 2f;
        public float patrolRange = 5f;
        public float turnDelay = 1f;
    }

    [System.Serializable]
    public class ChaseParams
    {
        public float chaseSpeed = 4f;
        public float sightDistance = 6f;
        public float loseSightDistance = 8f;
    }

    [System.Serializable]
    public class AttackParams
    {
        public float damage = 10f;
        public float attackRange = 1.5f;
        public float attackCoolDown = 1.5f;
    }
}
