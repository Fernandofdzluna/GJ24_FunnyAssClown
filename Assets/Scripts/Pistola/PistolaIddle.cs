using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaIddle : StateMachineBehaviour
{
    GameObject puntoPistola;
    public bool disparoListo = false;
    GameObject animatorPlayer;
    GameObject pistola;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        puntoPistola = GameObject.FindGameObjectWithTag("PuntoPistola");
        animatorPlayer = GameObject.FindGameObjectWithTag("MainCamera");
        pistola = GameObject.FindGameObjectWithTag("Pistola");
        pistola.transform.position = puntoPistola.transform.position;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        disparoListo = animatorPlayer.GetComponent<Animator>().GetBool("CanShoot");
        pistola.transform.position = puntoPistola.transform.position;

        if ((Input.GetMouseButtonDown(0)) && (disparoListo == true))
        {
            animator.SetBool("Shoot", true);
        }
    }
}
