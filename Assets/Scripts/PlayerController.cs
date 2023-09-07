using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public float walkSpeed = 3f;
    public float runSpeed = 8f;
    public float crouchSpeed = 1f;
    private float currentSpeed = 3f;

    public float gravity = -9.81f;
    public float jumpForce = 5f;

    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = walkSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            currentSpeed = crouchSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            currentSpeed = walkSpeed;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        characterController.Move(movement * currentSpeed * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpForce;
            }
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}

