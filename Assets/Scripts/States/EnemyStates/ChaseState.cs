using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    public ChaseState(StateMachine stateMachine, Enemy enemy) : base(stateMachine, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Enemy.StartAnimation("skeleton_move");
        Enemy.Chase();

        if(Enemy.CheckDistance(Enemy.Player.transform.position) >= Enemy.BlindDistance)
        {
            Enemy.StopAnimation();
            Enemy.StateMachine.ChangeState(Enemy.Patroling);
        }

        if(Enemy.CheckDistance(Enemy.Player.transform.position) <= Enemy.AttackDistance)
        {
            Enemy.StopAnimation();
            Enemy.StateMachine.ChangeState(Enemy.Attacking);
        }
    }
}
