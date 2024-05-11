using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaShoot : StateMachineBehaviour
{
    GameObject puntoPistola;
    GameObject pistola; 
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        puntoPistola = GameObject.FindGameObjectWithTag("PuntoPistola");
        pistola = GameObject.FindGameObjectWithTag("Pistola");
        pistola.transform.position = puntoPistola.transform.position;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pistola.transform.position = puntoPistola.transform.position;
        animator.SetBool("Shoot", false);
    }
}
