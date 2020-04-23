using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAITeddy : MonoBehaviour
{
    public enum EnemyStates
    {
        Idle = 0,
        Follow = 1,
        Attack = 2
    }
    
    private EnemyStates prevState;
    [SerializeField] private EnemyStates currentState;
    [SerializeField] private Transform player;
    [SerializeField] private float minDistToFollow;
    [SerializeField] private float minDistToAttack;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private float dist;
    private void Awake()
    {
       
    }

    private void Update()
    {
        CheckStateChange();
        DoAccordingToState();
    }

    private void CheckStateChange()
    {
        prevState = currentState;

        var distToPlayer = Vector3.Distance(transform.position, player.position);
        dist = (float) ((0.77/distToPlayer)*100);
        
        if (distToPlayer <= minDistToAttack)
        {
            currentState = EnemyStates.Attack;
        }
        else if(distToPlayer <= minDistToFollow)
        {
            currentState = EnemyStates.Follow;
        }
        else if (distToPlayer > minDistToFollow)
        {
            currentState = EnemyStates.Idle;
        }
    }

    private void DoAccordingToState()
    {
        switch (currentState)
        {
            case EnemyStates.Idle:
            default:
                DoIdle();
                break;
            case EnemyStates.Follow:
                DoFollow();
                break;

            case EnemyStates.Attack:
                DoAttack();
                break;

        }
    }

    private void DoIdle()
    {
        agent.isStopped = true;
        animator.SetBool("IsRunning",false);
        animator.SetBool("IsAttacking",false);
    }

    private void DoFollow()
    {
        agent.isStopped = false;
        agent.SetDestination(player.transform.position);
        animator.SetBool("IsRunning",true);
        animator.SetBool("IsAttacking",false);
    }

    
    private void DoAttack()
    {
        agent.isStopped = true;
        animator.SetBool("IsAttacking",true);
        animator.SetBool("IsRunning",false);
    }
}
