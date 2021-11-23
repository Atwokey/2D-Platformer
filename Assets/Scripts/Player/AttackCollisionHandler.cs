using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionHandler : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("Удар прошел");
            enemy.ApplyDamage(_player.Damage);

        }
    }
}
