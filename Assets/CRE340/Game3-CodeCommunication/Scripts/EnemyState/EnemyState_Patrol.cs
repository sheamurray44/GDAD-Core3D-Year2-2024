using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Patrol : IEnemyState
{
    private Vector3 patrolCenter;
    private Vector3 patrolTarget;
    private float patrolRange = 5f;
    private float patrolSpeed = 1.5f;
    private float targetReachedThreshold = 0.2f;
    private float idleProbability = 0.001f;
    public void Enter(Enemy enemy)
    {
        Debug.Log("Entering Patrol State");
        patrolCenter = enemy.transform.position;
        SetNewPatrolTarget(enemy);
    }

    public void Update(Enemy enemy)
    {
        if (enemy.target !=null && Vector3.Distance(enemy.transform.position, enemy.target.position) < enemy.chaseRange)
        {
            enemy.SetState(new EnemyState_Chase());
            return;
        }

        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, patrolTarget, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(enemy.transform.position, patrolTarget) < targetReachedThreshold )
        {
            SetNewPatrolTarget(enemy);
        }

        if (Random.value < idleProbability)
        {
            enemy.SetState(new EnemyState_Idle());
        }
    }

    public void Exit(Enemy enemy)
    {
        Debug.Log("Exiting Patrol State");
    }

    private void SetNewPatrolTarget(Enemy enemy)
    {
        float randomX = Random.Range(-patrolRange, patrolRange);
        float randomZ = Random.Range(-patrolRange, patrolRange);
        patrolTarget = patrolCenter + new Vector3(randomX, 0, randomZ);
    }
}
