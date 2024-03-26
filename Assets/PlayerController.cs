using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    Vector2 inputVector;

    [SerializeField]

    float speed = 3;

    Animator animator;


    [SerializeField]
    float gravityMultiplier = 4;

    float yVelocity = 0;


    bool isJumping = false;

    bool roling;
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        Vector3 movement =
           Camera.main.transform.right * inputVector.x
           + Camera.main.transform.forward * inputVector.y;

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Roling")) return;


        if (GetComponent<CharacterController>().isGrounded)
        {
            yVelocity = -1;

        }

        if (movement.magnitude > 0)
        {

            movement.y = 0;
            movement = movement.normalized;
            transform.forward = movement;

            animator.SetBool("Walk", true);
        }
        else animator.SetBool("Walk", false); 



        yVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        movement *= speed * Time.deltaTime;
        controller.Move(movement);
        movement.y = yVelocity;

    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
       animator.SetTrigger("rolling");
    }
}
