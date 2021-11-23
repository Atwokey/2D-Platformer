using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : EnemyState
{
    private float _elapsedTime;

    public HitState(StateMachine stateMachine, Enemy enemy) : base(stateMachine, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _elapsedTime = 0;
        Enemy.StartAnimation("_skeleton_attack");
    }

    public override void LogicUpdate()
    {
        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= Enemy.DelayBeforeAttack)
        {
            Enemy.StopAnimation();
            Enemy.StartAnimation("_skeleton_attack");
            _elapsedTime = 0;
        }

        if (Enemy.CheckDistance(Enemy.Player.transform.position) >= Enemy.ChaseDistance)
        {
            Enemy.StopAnimation();
            Enemy.StateMachine.ChangeState(Enemy.Chasing);
        }
    }
}
