using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle_Track : StateMachineBehaviour
{
    Rigidbody2D rb;
    GameObject player;

    Vector2 move;
    Vector2 yPos;
    [SerializeField] private float speed = 20f;

    float maxTimer = 10f;
    float timer;
    float minTimer = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("DamageTestPlayer");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= minTimer)
        {
            timer = maxTimer;
            animator.SetBool("isSlam", true);
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }

        yPos = new Vector2(0, player.transform.position.y);

        move = Vector2.MoveTowards(rb.position, yPos, speed * Time.fixedDeltaTime);
        rb.MovePosition(move);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
