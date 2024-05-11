using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayasoRecibirTiro : StateMachineBehaviour
{
    float actualSpeed;
    int disparosDesaparecer;
    int disparosActuales;
    private Transform target;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        disparosDesaparecer = animator.gameObject.GetComponent<PayasoAgent>().disparosDesaparecer;
        target = animator.gameObject.GetComponent<PayasoAgent>().Target;
        animator.gameObject.GetComponent<PayasoAgent>().disparosActuales -= 1;
        disparosActuales = animator.gameObject.GetComponent<PayasoAgent>().disparosActuales;
        actualSpeed = animator.GetBehaviour<PayasoController>().speed - 3;

        if (disparosActuales <= 0)
        {
            animator.SetBool("Hundido", true);
            animator.GetBehaviour<PayasoController>().speed = actualSpeed;
        }
        else
        {
            animator.SetBool("TiroRecibido", false);
            animator.GetBehaviour<PayasoController>().speed = actualSpeed;
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, target.position, actualSpeed * Time.deltaTime);
        animator.transform.LookAt(target);
        actualSpeed += 0.5f * Time.deltaTime;
    }
}
