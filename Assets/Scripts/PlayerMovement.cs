using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _force;

    private bool _grounded;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector2.left);
            _renderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector2.right);
            _renderer.flipX = false;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        else
        {
            if (_grounded)
                _animator.Play("idle");
        }

        

        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            Jump();
        }
    }

    private void Move(Vector2 direction) 
    {
        transform.Translate(direction * _speed * Time.deltaTime);
        if(_grounded)
            _animator.Play("run");
    }


    private void Jump()
    {
        _grounded = false;
        _animator.Play("jump");
        _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }

    private void Attack()
    {
        _animator.Play("attack1");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ground ground))
        {
            _grounded = true;
        }

        Debug.Log(_grounded);
    }
}
