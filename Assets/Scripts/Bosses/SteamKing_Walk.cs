using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamKing_Walk : StateMachineBehaviour
{
    Transform Boss;
    Rigidbody2D rb;
    int location = 0;
    public Transform[] HorizontalPoints;
    [SerializeField] private float speed = 20f;
    private Vector2 move;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = animator.GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        GameObject parent = GameObject.Find("BossMovement/HorizontalMovement");
        for(int i = 0 ; i < parent.transform.childCount; i++){
            HorizontalPoints[i] = parent.transform.GetChild(i);
        }
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        for (int i = 0 ; i < HorizontalPoints.Length; i++) {
            if (Boss.position == HorizontalPoints[i].position){
                if(i == HorizontalPoints.Length-1){
                    animator.SetBool("WalkUp", true);
                }
                location = i + 1;
                break;
            }
        }
        // switch(Boss.position) {
        //     case HorizontalPoints[0].position:
        //     location = 1;
        //     break;
        //     case HorizontalPoints[1].position:
        //     location == 2;
        //     break;
        //     case HorizontalPoints[2].position:
            
        //     break;
        //     default:
        //     break;

        // }
       
        switch(location){
            case 0:
            move = Vector2.MoveTowards(rb.position, HorizontalPoints[0].position, speed * Time.fixedDeltaTime);
            break;
            case 1:
            move = Vector2.MoveTowards(rb.position, HorizontalPoints[1].position, speed * Time.fixedDeltaTime);
            break;
            case 2:
            move = Vector2.MoveTowards(rb.position, HorizontalPoints[2].position, speed * Time.fixedDeltaTime);
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
