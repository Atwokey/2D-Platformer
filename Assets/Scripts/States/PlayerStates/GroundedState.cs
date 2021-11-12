using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : State
{
    private float _horizontalInput;

    public GroundedState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Character.Grounded)
        {
            if (_horizontalInput < 0.05 && _horizontalInput > -0.05)
                Character.AnimationPlay("idle");
            else
                Character.AnimationPlay("run");
        }

        Character.Move(_horizontalInput);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
