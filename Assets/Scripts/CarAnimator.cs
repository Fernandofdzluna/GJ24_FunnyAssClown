using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimator : StateMachineBehaviour
{
    public float rotationAnimation = 0f;
    bool A = false;
    bool D = false;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rotationAnimation = animator.GetFloat("Rotation");
        if (Input.GetKey(KeyCode.A))
        {
            bool A = true;
            if(rotationAnimation > -1)
            {
                rotationAnimation -= 3 * Time.deltaTime;

                animator.SetFloat("Rotation", rotationAnimation);
            }
        }
        else if (A == true)
        {
            if (rotationAnimation < 0)
            {
                rotationAnimation += 3 * Time.deltaTime;

                animator.SetFloat("Rotation", rotationAnimation);
            }
            else
            {
                rotationAnimation = 0f;
                animator.SetFloat("Rotation", 0);
                A = false;
            }
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            bool D = true;
            if (rotationAnimation < 1)
            {
                rotationAnimation += 3 * Time.deltaTime;

                animator.SetFloat("Rotation", rotationAnimation);
            }
        }
        else if (D == true)
        {
            if (rotationAnimation > 0)
            {
                rotationAnimation -= 3 * Time.deltaTime;

                animator.SetFloat("Rotation", rotationAnimation);
            }
            else
            {
                rotationAnimation = 0f;
                animator.SetFloat("Rotation", 0);
                D = false;
            }
        }
        animator.SetFloat("Rotation", rotationAnimation);
    }
}
