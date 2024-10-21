using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    public float health;
    public float damage;
    public float chaseRange;

    void Start()
    {
        health = enemyData.health;
        damage = enemyData.damage;
        chaseRange = enemyData.chaseRange;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 1F);
        Gizmos.DrawWireSphere(transform.position, enemyData.chaseRange);
    }
}
