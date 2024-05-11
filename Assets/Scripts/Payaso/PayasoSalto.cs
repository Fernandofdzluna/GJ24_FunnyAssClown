using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayasoSalto : StateMachineBehaviour
{
    Transform saltoPose;
    float actualSpeed;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        saltoPose = animator.gameObject.GetComponent<PayasoAgent>().saltoPose;
        actualSpeed = animator.GetBehaviour<PayasoController>().speed;
        animator.transform.position = saltoPose.transform.position;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = saltoPose.transform.position;
    }
}
