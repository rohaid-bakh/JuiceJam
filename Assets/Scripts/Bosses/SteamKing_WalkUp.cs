using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamKing_WalkUp : StateMachineBehaviour
{
    Transform Boss;
    Rigidbody2D rb;
    int location = 0;
    public Transform[] VerticalPoints;
    [SerializeField] private float speed = 20f;
    private Vector2 move;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = animator.GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        GameObject parent = GameObject.Find("BossMovement/VerticalMovement");
        for(int i = 0 ; i < parent.transform.childCount; i++){
            VerticalPoints[i] = parent.transform.GetChild(i);
        }
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        for (int i = 0 ; i < VerticalPoints.Length; i++) {
            if (Boss.position == VerticalPoints[i].position){
                if(i == VerticalPoints.Length-1){
                    animator.SetBool("WalkUp", false);
                }
                location = i + 1;
                break;
            }
        }
       
        switch(location){
            case 0:
            move = Vector2.MoveTowards(rb.position, VerticalPoints[0].position, speed * Time.fixedDeltaTime);
            break;
            case 1:
            move = Vector2.MoveTowards(rb.position, VerticalPoints[1].position, speed * Time.fixedDeltaTime);
            break;
            case 2:
            move = Vector2.MoveTowards(rb.position, VerticalPoints[2].position, speed * Time.fixedDeltaTime);
            break;
            default:
            break;
        }
        rb.MovePosition(move);
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        location = 0;
    }


}
