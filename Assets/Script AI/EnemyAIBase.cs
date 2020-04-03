using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIBase : MonoBehaviour
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
            case EnemyStates.Follow:
                DoFollow();
                break;

            case EnemyStates.Attack:
                DoAttack();
                break;

            case EnemyStates.Idle:
            default:
                DoIdle();
                break;
        }
    }

    private void DoIdle()
    {
        agent.isStopped = true;
    }

    private void DoFollow()
    {
        agent.isStopped = false;
        agent.SetDestination(player.transform.position);
    }

    
    private void DoAttack()
    {
        agent.isStopped = true;
    }
}
