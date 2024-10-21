using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private EnemyData enemy;
    private float distanceToTarget;
    private bool isProvoke;

    private NavMeshAgent navMeshAgent;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        isProvoke = false;
        distanceToTarget = Mathf.Infinity;
    }

    void Update()
    {
        ProvokeCheck();
    }

    private float DistanceToTarget()
    {
        return Vector3.Distance(target.position, this.transform.position);
    }

    private void ProvokeCheck()
    {
        distanceToTarget = DistanceToTarget();
        if(isProvoke)
        {
            EngageTarget();
        }
        else if(distanceToTarget < enemy.chaseRange)
        {
            isProvoke = true; // temporarily
        }
    }

    private void EngageTarget()
    {
        
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        Debug.Log("Got Attack");
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 1F);
        Gizmos.DrawWireSphere(transform.position, enemy.chaseRange);
    }
}
