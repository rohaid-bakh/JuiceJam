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
    public int isAttack;
    private float maxTimer = 10f;
    private float timer;
    private float minTimer = 0f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Boss = animator.GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        Boss.rotation = Quaternion.identity;
        rb.rotation = 0f;
        GameObject parent = GameObject.Find("BossMovement/HorizontalMovement");
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            HorizontalPoints[i] = parent.transform.GetChild(i);
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= minTimer){
            timer = maxTimer;
            Attack(animator);
        } else {
            timer -= Time.fixedDeltaTime;
        }

        for (int i = 0; i < HorizontalPoints.Length; i++)
        {
            if (Boss.position == HorizontalPoints[i].position)
            {
                if (i == HorizontalPoints.Length - 1)
                {
                    location = i + 1;
                    animator.SetBool("WalkUp", true);
                }
                location = i + 1;
                break;
            }
        }

        switch (location)
        {
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
        if (location == 3)
        {
            location = 0;
        }
    }

    void Attack(Animator animator)
    {
        isAttack = (int)Random.Range(0, 1000);
        if (isAttack % 12 == 0)
        {
            animator.SetBool("isBullet", true);
        } else if (isAttack % 14 == 0) {
            animator.SetBool("isSteam", true);
        }
    }

}
