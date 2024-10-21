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
}
