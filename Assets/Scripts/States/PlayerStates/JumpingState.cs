using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : MovementState
{
    public JumpingState(StateMachine stateMachine, Player player) : base(stateMachine, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.GroundHandling.Jumped();
        Player.Movement.Jump();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Player.GroundHandling.Grounded)
            StateMachine.ChangeState(Player.Standing);
    }
}
