using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected Character Character;

    public PlayerState(StateMachine stateMachine, Character character) : base(stateMachine)
    {
        Character = character;
    }
}
