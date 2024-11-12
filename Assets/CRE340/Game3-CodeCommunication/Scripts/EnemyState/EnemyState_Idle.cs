using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Idle : IEnemyState
{
    private float patrolProbability = 0.001f;
    public void Enter(Enemy enemy)
    {
        Debug.Log("Entering Idle State");
    }

    public void Update(Enemy enemy)
    {
        if (enemy.target == null) return;

        if (Vector3.Distance(enemy.transform.position, enemy.target.position) < enemy.chaseRange)
        {
            enemy.SetState(new EnemyState_Chase());  
        }

        if (Random.value < patrolProbability)
        {
            enemy.SetState(new EnemyState_Patrol());
        }
    }

    public void Exit(Enemy enemy)
    {
        Debug.Log("Exiting Idle State");
    }
}
