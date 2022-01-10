using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kraken_Swim : StateMachineBehaviour
{
    float timer;
    float maxTimer = 10f;
    float minTimer = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= minTimer)
        {
            timer = maxTimer;
            animator.SetBool("isAttack", true);
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
}