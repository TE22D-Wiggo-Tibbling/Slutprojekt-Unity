using System;
using System.Collections;
using System.Collections.Generic;
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
    float jumpForce = 10;

    [SerializeField]
    float gravityMultiplier = 4;

    float yVelocity = 0;

    [SerializeField]
    bool isJumping = false;
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



        if (GetComponent<CharacterController>().isGrounded)
        {
            yVelocity = -1;
            if (isJumping)
            {
                // yVelocity = jumpForce;
                animator.SetBool("jumping", true);
            }
            else
            {
                animator.SetBool("jumping", false);
            }
        }
        else{

        yVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }

        if (movement.magnitude > 0)
        {

            movement.y = 0;
            movement = movement.normalized;
            transform.forward = movement;
            animator.SetBool("Walk", true);
            if (GetComponent<CharacterController>().isGrounded)
        {
            if (isJumping)
            {
                animator.SetBool("jumping", true);
            }
            else
            {
                animator.SetBool("jumping", false);
            }
        }

        }
        else
        {
            animator.SetBool("Walk", false);
        }



        isJumping = false;
        movement.y = yVelocity;
        movement *= speed * Time.deltaTime;
        controller.Move(movement);

    }

    void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        isJumping = true;

    }

}
