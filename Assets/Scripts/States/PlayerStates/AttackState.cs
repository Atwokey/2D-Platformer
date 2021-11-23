using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    private float _delay;
    private float _elapsedTime;

    public AttackState(StateMachine stateMachine, Player player) : base(stateMachine, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _delay = 0.5f;
        _elapsedTime = 0;
        Player.Assault.Attack();
        Player.AnimationPlay("attack1");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _delay)
        {
            Player.AnimationStop();
            StateMachine.ChangeState(Player.Standing);
        }
    }
}
