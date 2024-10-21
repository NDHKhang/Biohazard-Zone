using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] EnemyData enemy;
    private float damage;

    void Start()
    {
        damage = enemy.damage;
    }

    public void AttackHitEvent()
    {
        if (target == null) return;

        Debug.Log("Ponk!");
    }
}
