using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : StateMachineBehaviour
{
    private UltBehaviour ultBehaviour;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ultBehaviour =  animator.gameObject.GetComponent<UltBehaviour>();
        ultBehaviour.AtkDelay();
    }


}
