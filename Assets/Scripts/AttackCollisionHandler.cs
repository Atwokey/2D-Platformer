using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionHandler : MonoBehaviour
{
    [SerializeField] private Character _character;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("Удар прошел");
            enemy.ApplyDamage(_character.Damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("Удар прошел");
            enemy.ApplyDamage(_character.Damage);

        }
    }
}
