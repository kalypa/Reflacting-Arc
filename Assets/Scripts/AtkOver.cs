using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkOver : StateMachineBehaviour
{
    private AtkBehaviour atkBehaviour;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        atkBehaviour = animator.GetComponent<AtkBehaviour>();
        atkBehaviour.state = AtkBehaviour.AnimationState.None;
        atkBehaviour.AtkEnd();
        atkBehaviour.atk = false;
        atkBehaviour.atk1Effect.SetActive(false);
        atkBehaviour.atk2Effect.SetActive(false);
        atkBehaviour.atk3Effect.SetActive(false);
        atkBehaviour.atk4Effect.SetActive(false);
        atkBehaviour.handSword.SetActive(false);
        atkBehaviour.sword.SetActive(true);
        animator.SetInteger("AtkState", 0);
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
