using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _collider;

    private SpriteRenderer _renderer;
    private readonly float _colliderOffsetX = 0.4f;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Attack()
    {
        if (_renderer.flipX)
            _collider.offset = new Vector2(-_colliderOffsetX, _collider.offset.y);
        else
            _collider.offset = new Vector2(_colliderOffsetX, _collider.offset.y);
    }
}
