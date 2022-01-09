using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamKing_ShootBullets : StateMachineBehaviour
{
    private SteamKing script;
    public float time = 0f;
    public float maxTime = 40f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       script = animator.GetComponent<SteamKing>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time += Time.fixedDeltaTime;
        if(time >= maxTime){
            time = 0f;
            animator.SetBool("isBullet", false);
        } else {
            script.Shoot("Bullet");
        }
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       script.Reset();
    }

    
}
