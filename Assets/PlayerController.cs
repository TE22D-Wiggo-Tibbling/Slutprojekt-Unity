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
    float jumpForce = 10;

    [SerializeField]
    float gravityMultiplier = 4;

    float yVelocity = 0;

    [SerializeField]
    bool isJumping = false;

    bool roling = false;
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
                isJumping = false;
            }
            else
            {
                animator.SetBool("jumping", false);
            }
        }

        if (movement.magnitude > 0)
        {

            movement.y = 0;
            movement = movement.normalized;
            animator.SetBool("Walk", true);
            if(roling){
        animator.SetBool("roling", true);
        roling = false;
            }
            else{
        animator.SetBool("roling", false);
            transform.forward = movement;
            }

        }
        else
        {
            animator.SetBool("Walk", false);
        }

        
        


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
        isJumping = true;

    }

    void OnFire(InputValue value){
        roling = true;
    }

}
