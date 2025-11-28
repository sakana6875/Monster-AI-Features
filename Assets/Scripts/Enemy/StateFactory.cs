using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public static class StateFactory
{
    public static BaseState CreateInitialState(EnemyType type, Enemy enemy)
    {
        return type switch
        {
            EnemyType.Goblin => new GoblinPatrolState(enemy),
            _ => null
        };
    }

    public static BaseState CreateChaseState(EnemyType type, Enemy enemy)
    {
        return type switch
        {
            EnemyType.Goblin => new GoblinChaseState(enemy),
            _ => null,
        };
    }
}
