using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected Player Player;

    public PlayerState(StateMachine stateMachine, Player player) : base(stateMachine)
    {
        Player = player;
    }
}
