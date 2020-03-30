using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFix : MonoBehaviour
{
    [SerializeField]private Animator animator;
    private bool R1 = false;
    void Hit()
    {

    }

    void Land()
    {
        
    }

    private void Update()
    {
        void Update()
        {
            animator.SetBool("R1",R1);
            
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("RM");
                R1 = true;
            }
        }
    }
}
