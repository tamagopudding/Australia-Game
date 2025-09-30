using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThirdPersonCam : MonoBehaviour
{
    public Pause_Menu GameIsPaused;

    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public PlayerMovement playerMovement;

    public float rotationSpeed;

    private void Start()
    {
        if (GameIsPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            //Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;   
            //Cursor.visible = true;
            Cursor.visible = false;
        }
        

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    private void Update()
    {
        // rotate orientation base on swimming or not
        //? acts as if statement and : works as else if aka ternary operator
        //old script
        //Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        Vector3 viewDir = player.position - (playerMovement.isSwimming ? transform.position: new Vector3(transform.position.x, player.position.y, transform.position.z));
        orientation.forward = viewDir.normalized;

        // rotate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        

        if (inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
