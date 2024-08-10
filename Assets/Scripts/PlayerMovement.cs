using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
 
    public float speed = 10f;
    public float gravity = -9.81f * 2;
    public float sprintFactor = 2f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
 
    Vector3 velocity;
 
    bool isGrounded;
 
    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
 
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
 
        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * speed * sprintFactor * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        Debug.Log(isGrounded);
        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity)*2;
        }
 
        velocity.y += gravity * Time.deltaTime*5;
 
        controller.Move(velocity * Time.deltaTime);
    }
}