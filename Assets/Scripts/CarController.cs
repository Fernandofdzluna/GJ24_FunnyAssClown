using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolsaBasuraController : MonoBehaviour
{
    public float speed = 10;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 8;


    public GameObject player;
    public GameObject camaraPlayer;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDir = new Vector3(0, 0, 1);
            moveDir *= speed;
            moveDir = transform.TransformDirection(moveDir);
            if (Input.GetKeyUp(KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 0);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    transform.Rotate(0f, 180f, 0f);
        //}
        //else if (Input.GetKeyUp(KeyCode.F))
        //{
        //    transform.Rotate(0f, -180f, 0f);
        //}
    }
}
