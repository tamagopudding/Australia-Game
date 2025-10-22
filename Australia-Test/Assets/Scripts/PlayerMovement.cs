using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using System.Security.Cryptography.X509Certificates;

public class PlayerMovement : MonoBehaviour
{
    

    //Swimming
    [HideInInspector]
    public bool isSwimming;
    public float swimSpeed;
    public Transform target;

    //Normal Movement
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    //private CharacterController controller;

    //aniamtions
    public Animator animator;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //controller = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        //color
        Shader.SetGlobalVector("_TurtlePosition", transform.position);

        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        //Animations
        float speed = new Vector2(horizontalInput, verticalInput).magnitude;
        animator.SetFloat("Speed", speed);
       



        // Handle drag 
        // had to use linear damping not drag as drag is obsolete  
        if (grounded)
        {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }
    }

    private void FixedUpdate()
    {
        if(isSwimming != true)
        {
            if(rb.useGravity != true)
            {
                rb.useGravity = true;
            }
            MovePlayer();
        }
        else
        {
            if(rb.useGravity == true)
            {
                rb.useGravity = false;
            }
            if(Input.GetAxisRaw("Vertical") > 0)
            {
                transform.position += target.forward * swimSpeed * Time.deltaTime;
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                transform.position -= target.forward * swimSpeed * Time.deltaTime;
            }
            if (Input.GetAxisRaw("Horizontal") > 0) // this is likely where horizontal input needs to be added for swimming
            {
                transform.position += target.right * swimSpeed * Time.deltaTime;
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                transform.position -= target.right * swimSpeed * Time.deltaTime;
            }
             
        }
    }

    public void ResetVelocity()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void MyInput()
    {
        //get access horizontal is getting keys A and D
        horizontalInput = Input.GetAxisRaw("Horizontal");
        //get axis vertical is getting keys W and S
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;


        // on ground
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        //in air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}



//{
// idk what these are
//    [SerializeField] Material Greyscale;
//    [SerializeField] Shader _TurtlePosition;
//    [SerializeReference]

// trying to make it so the shader grabs the co-ords of the player and uses those
// in the shader graph
//private void Update ()
//    Vector3 playerPosition = Transform.postion;

    //send player pos to shader
//    _TurtlePosition.SetVector("_TutlePos", playerPostion)
//}

//something about grabbing the material the shader is connected (beach sand) and 