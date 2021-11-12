using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : GroundedState
{
    private bool _jumped;
    private bool _attacked;

    public StandingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _jumped = false;
        _attacked = false;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _jumped = Input.GetKeyDown(KeyCode.Space);
        _attacked = Input.GetMouseButtonDown(0);
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_jumped)
        {
            Character.AnimationStop();
            StateMachine.ChangeState(Character.Jumping);
        }

        if (_attacked)
        {
            Character.AnimationStop();
            StateMachine.ChangeState(Character.Attacking);
        }
    }
}
