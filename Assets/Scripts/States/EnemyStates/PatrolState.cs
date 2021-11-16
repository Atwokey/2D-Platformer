using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
    public PatrolState(StateMachine stateMachine, Enemy enemy) : base(stateMachine, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Enemy.StartAnimation("skeleton_move");
        Enemy.ChangeDirection();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Enemy.Patrol();

        if(Enemy.CheckDistance(Enemy.Character.transform.position) <= Enemy.ChaseDistance)
        {
            Enemy.StopAnimation();
            Enemy.StateMachine.ChangeState(Enemy.Chasing);
        }
        
    }
}
