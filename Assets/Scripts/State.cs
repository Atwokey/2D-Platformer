using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Character Character;
    protected StateMachine StateMachine;

    public State(Character character, StateMachine stateMachine)
    {
        Character = character;
        StateMachine = stateMachine;
    }

    public  virtual void Enter()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
