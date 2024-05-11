using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayasoDesaparecer : StateMachineBehaviour
{
    float actualSpeed;
    private Transform target;
    Vector3 actualPose;
    public GameObject spawnPayaso;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("TiroRecibido", false);
        animator.SetBool("Hundido", false);
        actualSpeed = animator.GetBehaviour<PayasoController>().speed;
        target = animator.gameObject.GetComponent<PayasoAgent>().Target;
        spawnPayaso = GameObject.FindGameObjectWithTag("SpawnPayaso");
        actualPose = new Vector3(0, 0, 0);
        actualPose = animator.transform.position;
        spawnPayaso.transform.position = actualPose;
        animator.gameObject.GetComponent<PayasoAgent>().disparosActuales = animator.gameObject.GetComponent<PayasoAgent>().disparosDesaparecer;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, target.position, actualSpeed * Time.deltaTime);
        animator.transform.LookAt(target);
    }
}
