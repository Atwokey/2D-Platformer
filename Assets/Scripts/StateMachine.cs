using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; private set; }

    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        SetState(startingState);
    }

    public void ChangeState(State nextState)
    {
        CurrentState.Exit();
        SetState(nextState);
    }

    private void SetState(State state)
    {
        CurrentState = state;
        state.Enter();
    }
}
