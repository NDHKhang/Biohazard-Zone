using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Enemy enemy;
    private float distanceToTarget;
    private bool isProvoke;

    private NavMeshAgent navMeshAgent;
    private EnemyAnimation anim;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<EnemyAnimation>();
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
        anim.AttackState(true);
        Debug.Log("Got Attack");
    }

    private void ChaseTarget()
    {
        anim.MoveState();
        anim.AttackState(false);
        navMeshAgent.SetDestination(target.position);
    }
}
