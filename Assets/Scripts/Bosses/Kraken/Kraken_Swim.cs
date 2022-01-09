//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Kraken_Swim : StateMachineBehaviour
//{
//    Transform krakenKing;
//    Rigidbody2D rb;
//    public Transform[] movementPoints;
//    Vector2 move;
//    [SerializeField] private float speed = 20f;
//    int location = 0;
//    float timer;
//    float maxTimer = 5f;
//    float minTimer = 0f;

//    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        krakenKing = animator.GetComponent<Transform>();
//        rb = animator.GetComponent<Rigidbody2D>();
//        GameObject parent = GameObject.Find("KrakenMovement");

//        for (int i = 0; i < parent.transform.childCount; i++)
//        {
//            movementPoints[i] = parent.transform.GetChild(i);
//        }
//    }

//    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        if (timer <= minTimer)
//        {
//            timer = maxTimer;
//            location = 2;

//            animator.SetBool("isAttack", true);
//        }
//        else
//        {
//            timer -= Time.fixedDeltaTime;
//        }

//        for (int i = 0; i < movementPoints.Length; i++)
//        {
//            if (krakenKing.position == movementPoints[i].position)
//            {
//                location = i + 1;

//                if (location == 3)
//                {
//                    location = 0;
//                }
//                break;
//            }

//        }

//        switch (location)
//        {
//            case 0:
//                move = Vector2.MoveTowards(rb.position, movementPoints[0].position, speed * Time.fixedDeltaTime);
//                break;
//            case 1:
//                move = Vector2.MoveTowards(rb.position, movementPoints[1].position, speed * Time.fixedDeltaTime);
//                break;
//            case 2:
//                move = Vector2.MoveTowards(rb.position, movementPoints[2].position, speed * Time.fixedDeltaTime);
//                break;
//            default:
//                break;
//        }
//        rb.MovePosition(move);


//    }

//    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        if (location == 3)
//        {
//            location = 0;
//        }
//    }
//}

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
