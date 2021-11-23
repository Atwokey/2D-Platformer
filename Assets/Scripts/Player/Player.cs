using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(PlayerAttackController))]
[RequireComponent(typeof(GroundHandling))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    public int Damage => _damage;
    public StateMachine StateMachine { get; private set; }
    public StandingState Standing { get; private set; }
    public JumpingState Jumping { get; private set; }
    public AttackState Attacking { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerMovementController Movement { get; private set; }
    public PlayerAttackController Assault { get; private set; }
    public GroundHandling GroundHandling { get; private set; }

    private void Start()
    {
        Movement = GetComponent<PlayerMovementController>();
        Assault = GetComponent<PlayerAttackController>();
        GroundHandling = GetComponent<GroundHandling>();

        StateMachine = new StateMachine();

        Standing = new StandingState(StateMachine, this);
        Jumping = new JumpingState(StateMachine, this);
        Attacking = new AttackState(StateMachine, this);

        StateMachine.Initialize(Standing);

        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        StateMachine.CurrentState.HandleInput();
        StateMachine.CurrentState.LogicUpdate();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void AnimationPlay(string stateName)
    {
        Animator.Play(stateName);
    }

    public void AnimationStop()
    {
        Animator.StopPlayback();
    }
}
