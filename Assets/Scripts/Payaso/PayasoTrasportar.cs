using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayasoTrasportar : StateMachineBehaviour
{
    private GameObject spawnPayaso;
    private Transform target;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("TiroRecibido", false);
        spawnPayaso = GameObject.FindGameObjectWithTag("SpawnPayaso");
        target = animator.gameObject.GetComponent<PayasoAgent>().Target;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = spawnPayaso.transform.position;
        animator.transform.LookAt(target);
    }
}
