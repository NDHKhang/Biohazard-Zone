using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void IdleStae()
    {
        animator.SetTrigger("idle");
    }

    public void MoveState()
    {
        animator.SetTrigger("move");
    }

    public void AttackState(bool state)
    {
        animator.SetBool("attack", state);
    }
}
