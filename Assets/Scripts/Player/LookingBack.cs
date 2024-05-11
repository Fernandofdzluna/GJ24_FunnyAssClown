using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingBack : StateMachineBehaviour
{
    public float rotationSpeed;
    float rotation = 0f;
    float velocidad;
    bool girando = true;
    Camera cam;
    GameObject payaso;
    GameObject brazoIzq;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rotation = 0f;
        velocidad = rotationSpeed;
        girando = true;
        cam = Camera.main;
        payaso = GameObject.FindGameObjectWithTag("ObjetivoPistola");
        brazoIzq = GameObject.FindGameObjectWithTag("BrazoIzq");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        if (Input.GetKeyDown(KeyCode.E))
        {
            girando = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            girando = false;
            animator.SetBool("CanShoot", false);
        }

        if (girando == true)
        {

            animator.transform.Rotate(0.0f, Time.deltaTime * rotationSpeed, 0.0f);
            rotation += Time.deltaTime * rotationSpeed;

            if (rotation >= 180)
            {
                Cursor.visible = true;
                rotationSpeed = 0;
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 100f;
                mousePos = cam.ScreenToWorldPoint(mousePos);
                Debug.DrawRay(animator.transform.position, mousePos - animator.transform.position, Color.blue);

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 10000000) && (hit.collider.tag == "ObjetivoPistola"))
                    {
                        payaso.GetComponent<Animator>().SetBool("TiroRecibido", true);
                    }
                    payaso.GetComponent<Animator>().SetBool("TiroRecibido", true);
                }
                animator.SetBool("CanShoot", true);
            }
        }
        else if (girando == false)
        {
            Cursor.visible = false;
            rotationSpeed = velocidad;
            animator.transform.Rotate(0.0f, -Time.deltaTime * rotationSpeed, 0.0f);
            rotation -= Time.deltaTime * rotationSpeed;

            if (rotation <= 0)
            {
                animator.SetBool("LookBack", false);
            }
        }
    }
}
