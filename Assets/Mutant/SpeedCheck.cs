using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCheck : MonoBehaviour
{
    Vector3 PreviousFramePosition = Vector3.zero; // Or whatever your initial position is
    private float Speed = 0f;
    [SerializeField] private Animator animator;
 
    void Update ()
    {
        float movementPerFrame = Vector3.Distance (PreviousFramePosition, transform.position) ;
        Speed = movementPerFrame / Time.deltaTime;
        PreviousFramePosition = transform.position;
        animator.SetFloat("Speed",Speed);
    }
}
