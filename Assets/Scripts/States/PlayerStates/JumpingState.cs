using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : GroundedState
{
    public JumpingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Character.Jump();
        Character.AnimationPlay("jump");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Character.Grounded)
        {
            Character.AnimationStop();
            StateMachine.ChangeState(Character.Standing);
        }
    }
}
