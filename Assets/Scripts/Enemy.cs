using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();    
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
}
