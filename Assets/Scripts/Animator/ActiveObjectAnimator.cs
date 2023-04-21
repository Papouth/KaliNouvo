using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveObjectAnimator : StateMachineBehaviour
{
    private ActivateObject[] objectToActivate;
    public string nameObject;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        objectToActivate = animator.gameObject.GetComponentsInChildren<ActivateObject>();

        if (objectToActivate.Length > 0)
        {
            foreach (ActivateObject obj in objectToActivate)
            {
                if (obj.name == nameObject)
                {
                    obj.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (objectToActivate.Length > 0)
        {
            foreach (ActivateObject obj in objectToActivate)
            {
                if (obj.name == nameObject)
                {
                    obj.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
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
