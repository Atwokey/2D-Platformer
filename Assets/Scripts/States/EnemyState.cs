using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : State
{
    protected Enemy Enemy;
    public EnemyState(StateMachine stateMachine, Enemy enemy) : base(stateMachine)
    {
        Enemy = enemy;
    }
}
