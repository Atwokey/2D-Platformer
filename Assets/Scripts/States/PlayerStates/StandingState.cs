using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : MovementState
{
    private bool _jumped;
    private bool _attacked;

    public StandingState(StateMachine stateMachine, Player player) : base(stateMachine, player)
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
            StateMachine.ChangeState(Player.Jumping);
        }

        if (_attacked)
        {
            Player.AnimationStop();
            StateMachine.ChangeState(Player.Attacking);
        }
    }
}
