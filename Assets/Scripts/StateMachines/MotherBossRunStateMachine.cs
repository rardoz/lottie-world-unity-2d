using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherBossRunStateMachine : StateMachineBehaviour
{
    RobotController player;
    Mother mother;
    Transform playerTransform;
    Rigidbody2D rb;

    public float speed = 2.5f;
    public float attackRange = 3f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<RobotController>();
        playerTransform = player.transform;
        rb = animator.GetComponent<Rigidbody2D>();
        mother = GameObject.FindGameObjectWithTag("Boss").GetComponent<Mother>();
        if (speed == 0)
        {
            speed = player.Playerspeed;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mother.LookAtPlayer();
        Vector2 target = new Vector2(playerTransform.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        if (Vector2.Distance(playerTransform.position, rb.position) <= attackRange)
        {
            animator.SetBool("Attack", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Attack", false);
    }
}
