using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _patrolArea;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _delayBeforeAttack;
    [SerializeField] private float _chaseDistance;
    [SerializeField] private float _blindDistance;
    [SerializeField] private float _circleOffsetX;
    [SerializeField] private CircleCollider2D _attackCollider;

    private StateMachine _stateMachine;
    private PatrolState _patroling;
    private ChaseState _chasing;
    private HitState _attacking;
    private Animator _animator;
    private SpriteRenderer _renderer;
    private Point[] _points;
    private Vector3 _currentTarget;
    private int _currentPoint;

    public StateMachine StateMachine => _stateMachine;
    public PatrolState Patroling => _patroling;
    public ChaseState Chasing => _chasing;
    public HitState Attacking => _attacking;
    public float AttackDistance => _attackDistance;
    public float DelayBeforeAttack => _delayBeforeAttack;
    public float ChaseDistance => _chaseDistance;
    public float BlindDistance => _blindDistance;
    public Player Player => _player;
    public int Damage => _damage;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _points = _patrolArea.GetComponentsInChildren<Point>();

        _stateMachine = new StateMachine();
        _patroling = new PatrolState(_stateMachine, this);
        _chasing = new ChaseState(_stateMachine, this);
        _attacking = new HitState(_stateMachine, this);

        _stateMachine.Initialize(_patroling);
    }

    private void Update()
    {
        _stateMachine.CurrentState.LogicUpdate();
    }

    public void Move()
    {
        CheckDirection();
        transform.position = Vector2.MoveTowards(transform.position, _currentTarget,_speed * Time.deltaTime);
    }

    private void CheckDirection()
    {
        Vector3 direction = (_currentTarget - transform.position).normalized;

        if(direction.x > 0)
        {
            _renderer.flipX = false;
            _attackCollider.offset = new Vector2(_circleOffsetX, 0); 
        }
        else if(direction.x < 0)
        {
            _renderer.flipX = true;
            _attackCollider.offset = new Vector2(-(1 + _circleOffsetX), 0);
        }
    }

    public void Patrol()
    {
        if (CheckDistance(_currentTarget) <= 0.5f)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;

            ChangeDirection();
        }

        Move();
    }

    public float CheckDistance(Vector3 target)
    {
        return Vector2.Distance(transform.position, target);
    }

    public void ChangeDirection()
    {
        _currentTarget = _points[_currentPoint].transform.position;
    }

    public void Chase()
    {
        _currentTarget = _player.transform.position;
        Move();
    }

    public void ApplyDamage(int damage)
    {
        _animator.Play("skeleton_hit");
        _health -= damage;
        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void StartAnimation(string state)
    {
        _animator.Play(state);
    }

    public void StopAnimation()
    {
        _animator.StopPlayback();
    }
}
