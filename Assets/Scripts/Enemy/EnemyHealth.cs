using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    public void TakeDamage(float amount)
    {
        enemy.health -= amount;

        if (enemy.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
