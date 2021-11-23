using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollisionHandler : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_enemy.Damage);
        }
    }
}
