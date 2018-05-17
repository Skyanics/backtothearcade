using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Player : MonoBehaviour
{

    //Arduino
    SerialPort sp = new SerialPort("COM3", 9600);

    private CharacterController controller;
    public Vector2 speed;
    private float verticalVelocity;
    public float Gravity;
    public float jumpForce = 10.0f;
    public bool isPulling;
    public ParticleSystem atkParticle;

    private Quaternion rot;
    private Vector3 moveVector;
    private Vector3 lastMove;

    public Animator anim;
    string[] parsed;

    private bool wallJumped = false;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();

        sp.Open();
        sp.ReadTimeout = 1;
        sp.BaudRate = 9600;
    }

    string[] ParseInput(string input)
    {
        if(input != "error")
        {
            parsed = input.Split('_');
        }
         return parsed;
    }

    Vector2 inputMov;

    void FixedUpdate()
    {
        string message = "";
        try
        {
            message = sp.ReadLine();
        }
        catch
        {
            message = "error";
        }
        ParseInput(message);


        inputMov = Vector2.zero;
        for(int i = 0; i < parsed.Length && i < 2; i++)
        {
            float possibleResult = 0;
            inputMov[i] = float.TryParse(parsed[i], out possibleResult) ? possibleResult : 0;
        }

        //inputMov.x = moveVector.x;
        //Debug.Log(inputMov);
	}


    // Update is called once per frame
    void Update()
    {
       Jumping();

       
        controller.Move(new Vector3(inputMov.x * speed.x, verticalVelocity, controller.transform.position.z) * Time.deltaTime);
        lastMove = moveVector;

        var partrot = atkParticle.rotationOverLifetime;
        partrot.z = 0;

        if (rot == Quaternion.LookRotation(Vector3.left))
        {
            partrot.z = 15;
        }

        else
        {
            partrot.z = -15;
        }

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
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, controller.velocity.magnitude * Time.deltaTime);
        }

        if (transform.position.z != -6.9)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -6.9f);
        }
    }
    
    private void Jumping()
    {
     if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
        {
            anim.SetBool("isRunning", true);
        }
        else 
        {
            anim.SetBool("isRunning", false);
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetBool("isPushing", true);
        }
        else
        {
            anim.SetBool("isPushing", false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("isAttacking", true);
            atkParticle.Play();
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

        if (controller.isGrounded)
        {
            verticalVelocity = -1;
            wallJumped = false;
            anim.SetBool("isJumping", false);
            anim.SetBool("isGrounded", true);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("isGrounded", false);
                anim.SetBool("isJumping", true);
                verticalVelocity = jumpForce;
            }

            Debug.Log(parsed[2]);

            if(parsed[2] == "Ft")
            {
                anim.SetBool("isGrounded", false);
                anim.SetBool("isJumping", true);
                verticalVelocity = jumpForce;
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
        moveVector *= speed.y;
        moveVector.y = verticalVelocity;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controller.isGrounded && hit.normal.y < 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
                verticalVelocity = jumpForce;
                moveVector = hit.normal * speed.y;
                rot = Quaternion.LookRotation(hit.normal);
                wallJumped = true;
            }
        }

    }
}
