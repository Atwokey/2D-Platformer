using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : PlayerState
{
    private float _horizontal;

    public MovementState(StateMachine stateMachine, Player player) : base(stateMachine, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _horizontal = 0;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        _horizontal = Input.GetAxis("Horizontal");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Debug.Log(Player.GroundHandling.Grounded);
        Debug.Log(_horizontal);
        if (Player.GroundHandling.Grounded)
        {
            if (_horizontal < 0.09 && _horizontal >= -0.09)
                Player.AnimationPlay("idle");
            else
                Player.AnimationPlay("run");
        }

        Player.Movement.Move(_horizontal);
    }
}
