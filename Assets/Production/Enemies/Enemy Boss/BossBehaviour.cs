using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : EnemyMovement
{
    private int attackCount = 0;

    protected override void Attack()
    {
        if (!attackPlayer)
            return;

        current_Attack_Time += Time.deltaTime;

        if (current_Attack_Time > default_Attack_Time)
        {
            if (attackCount < 3)
            {

                enemyAnim.EnemyAttack(Random.Range(0, 3));

                attackCount++;
                current_Attack_Time = 0f;

            }
            else
            {
                enemyAnim.EnemyAttack(3);

                attackCount = 0;
                current_Attack_Time = 0f;
            }
        }
        

        if (Vector3.Distance(transform.position, playerTarget.position) >
                attack_Distance + chase_Player_After_Attack)
        {

            attackPlayer = false;
            followPlayer = true;

        }
    }
}
