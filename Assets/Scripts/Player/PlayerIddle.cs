using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIddle : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.localEulerAngles = Vector3.zero;
        Cursor.visible = false;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   
            animator.SetBool("LookBack", true);
        }
    }
}
