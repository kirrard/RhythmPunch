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
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("Hit", true);
            timingManager.CheckTiming();
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.K))
        {
            animator.SetBool("Hit", false);
        }
    }
}
