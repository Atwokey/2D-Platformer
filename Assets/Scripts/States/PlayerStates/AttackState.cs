using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    private float _delay;
    private float _elapsedTime;

    public AttackState(StateMachine stateMachine, Character character) : base(stateMachine, character)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _delay = 0.5f;
        _elapsedTime = 0;
        Character.Attack();
        Character.AnimationPlay("attack1");
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _delay)
        {
            Character.AnimationStop();
            StateMachine.ChangeState(Character.Standing);
        }
    }
}
