using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayasoController : StateMachineBehaviour
{
    public float speed = 15.0f;
    private Transform target;
    private Transform saltoPose;
    GameObject player;
    bool saltoPreparado = false;
    bool saliendoIddle = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = animator.gameObject.GetComponent<PayasoAgent>().Target;
        player = GameObject.FindGameObjectWithTag("Player");
        saltoPose = animator.gameObject.GetComponent<PayasoAgent>().saltoPose;
        speed = animator.GetBehaviour<PayasoController>().speed;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(saliendoIddle == false)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, target.position, speed * Time.deltaTime);
            animator.transform.LookAt(target);
            speed += 0.5f * Time.deltaTime;
        }

        float dist = Vector3.Distance(player.transform.position, animator.transform.position);
        if(dist <= 5)
        {
            if(speed > 20)
            {
                speed -= 0.5f * Time.deltaTime;
            }

            if (saltoPreparado == false)
            {
                speed = 15f;
                saliendoIddle = true;
                animator.transform.position = Vector3.MoveTowards(animator.transform.position, saltoPose.position, speed * Time.deltaTime);
                animator.transform.LookAt(saltoPose);

                float dis = Vector3.Distance(saltoPose.transform.position, animator.transform.position);
                if (dis < 1)
                {
                    saltoPreparado = true;
                }
            }
            else
            {
                animator.SetBool("Salto", true);
            }
        }
        else
        {
            saliendoIddle = false;
        }
    }
}
