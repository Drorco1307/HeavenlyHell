using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBossAI : MonoBehaviour
{
    public enum EnemyStates
    {
        Idle = 0,
        Attack = 1,
        RangeAttack = 2,
        HealSelf = 3,
        Confused = 4
    }

    private bool isStateChanged = false;
    private EnemyStates prevState;
    [SerializeField] private EnemyStates currentState;

    [SerializeField] private Transform player;

    [SerializeField] private float minDistToRangeAttack;
    [SerializeField] private float minDistToAttack;

    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject projectile;
    
    [SerializeField] private float attackDamage;
    [SerializeField] private float rangeAttackDamage;
    [SerializeField] private float rateAttack;
    [SerializeField] private float rangeRateAttack;
    [SerializeField] private float healPerSec;

    [SerializeField] private float attackTimeCounter = 0;
    
    private void Awake()
    {
        
    }

    private void Update()
    {
        attackTimeCounter += Time.deltaTime;
        
        CheckStateChange();
        DoAccordingToState();
    }

    private void CheckStateChange()
    {
        if (currentState == EnemyStates.Confused)
        {
            return;
        }
        
        prevState = currentState;

        var distToPlayer = Vector3.Distance(transform.position, player.position);

        if (distToPlayer <= minDistToAttack)
        {
            currentState = EnemyStates.Attack;
        }
        else if(distToPlayer <= minDistToRangeAttack)
        {
            currentState = EnemyStates.RangeAttack;
        }
        else
        {
            currentState = EnemyStates.HealSelf;
        }

        isStateChanged = prevState != currentState;
    }

    private void DoAccordingToState()
    {
        switch (currentState)
        {
            case EnemyStates.Attack:
                TryMeleeAttack();
                break;

            case EnemyStates.RangeAttack:
                TryRangeAttack();
                break;
            
            case EnemyStates.HealSelf:
                DoHeal();
                break;

            case EnemyStates.Confused:
                DoConfuse();
                break;
            
            case EnemyStates.Idle:
            default:
                break;
        }
    }

    public void GotConfused()
    {
        currentState = EnemyStates.Confused;
        Invoke("StopConfusion", 3f);
    }

    private void StopConfusion()
    {
        currentState = EnemyStates.HealSelf;
    }
    
    private void DoConfuse()
    {
        Debug.Log("confused");
    }

    private void TryMeleeAttack()
    {
        if (attackTimeCounter >= rateAttack)
        {
            Debug.Log($"Attack: {attackDamage}");
            attackTimeCounter = 0;
        }
    }
    
    private void TryRangeAttack()
    {
        if (attackTimeCounter >= rangeRateAttack)
        {
            Debug.Log($"Range Attack: {rangeAttackDamage}");
            attackTimeCounter = 0;
        }
    }
    
    private void DoHeal()
    {
        //Debug.Log($"Heal: {(healPerSec * Time.deltaTime)}");
    }
}
