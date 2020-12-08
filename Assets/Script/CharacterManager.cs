using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    Animator animator;
    TimingManager timingManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        timingManager = FindObjectOfType<TimingManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("Hit", true);
            timingManager.CheckTiming();
        }
        else if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.F))
        {
            animator.SetBool("Hit", false);
        }
    }
}
