﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5.0f;
    private float verticalVelocity;
    public float Gravity;
    public float jumpForce = 10.0f;
    public bool isPulling;

    private Quaternion rot;
    private Vector3 moveVector;
    private Vector3 lastMove;

    public Animator anim;

    private bool wallJumped = false;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
        {
            anim.SetBool("isRunning", true);
        }

        else {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.M))
        {
            anim.SetBool("isDancing", true);
        }

        else
        {
            anim.SetBool("isDancing", false);
        }

        if (controller.isGrounded)
        {
            verticalVelocity = -1;
            wallJumped = false;
            anim.SetBool("isJumping", false);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
                anim.SetBool("isJumping", true);
            }
        }

        else if (wallJumped == true)
        {
            moveVector = lastMove;
            verticalVelocity -= Gravity * Time.deltaTime;
        }

        else
        {
            verticalVelocity -= Gravity * Time.deltaTime;
        }


        moveVector.y = 0;
        moveVector.Normalize();
        moveVector *= speed;
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);
        lastMove = moveVector;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rot = Quaternion.LookRotation(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rot = Quaternion.LookRotation(Vector3.right);
        }

        if (!isPulling)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);
        }

        if (transform.position.z != -6.9)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -6.9f);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controller.isGrounded && hit.normal.y < 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
                verticalVelocity = jumpForce;
                moveVector = hit.normal * speed;
                rot = Quaternion.LookRotation(hit.normal);
                wallJumped = true;
            }
        }

    }
}
