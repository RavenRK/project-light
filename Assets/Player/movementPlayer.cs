using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class movementPlayer : MonoBehaviour
{
    [Header("Player settings")]
    public float RunSpeed = 12f;
    public float WalkSpeed = 6f;
    public float jumpForce = 5f;                                                                    // Jump force for the player
    public float gravity = -9.81f;                                                                  // Gravity force for the player
    
    private float moveSpeed = 6;
    private Vector2 moveInput;
    private Rigidbody rb;
    public Transform playerCamera;

    [Header("Ground Check Settings")]
    bool isGrounded = true;                                                                          // Check if the player is on the ground
    public float groundCheckDis = 1.1f;
    public LayerMask groundLayer;                                                                   // layer mask for the ground
    public Transform groundCheckOrigin;                                                             // groudn start point

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        
        Vector3 forward = playerCamera.forward;                                                      // Get the forward and right vectors of the camera
        Vector3 right = playerCamera.right;

        forward.y = 0f;                                                                              // Set the y component to 0 to ignore vertical movement
        right.y = 0f;

        forward.Normalize();                                                                         // Normalize the vectors to ensure consistent movement speed ( forward and right is 1 for * movespeed )
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;                         // Calculate the movement direction based on input
        Vector3 moveVelocity = moveDirection * moveSpeed;

        rb.linearVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);        // Apply the movement velocity to the rigidbody ( physics base movement)
        rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);                                   // Apply gravity to the rigidbody
    }
    public void OnMove(InputAction.CallbackContext context)
    {
            moveInput = context.ReadValue<Vector2>();                                               // Get the input value from the input system
    }
    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
            moveSpeed = RunSpeed;                                                                      // Increase the move speed when running
        else if (context.canceled)
            moveSpeed = WalkSpeed;                                                                     // Reset the move speed when not running
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isGrounded = Physics.Raycast(groundCheckOrigin.position, Vector3.down, groundCheckDis, groundLayer); // Check if the player is on the ground using a raycast
            if (isGrounded)                                                                           // Check if the player is on the ground
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);                              // Apply the jump force to the rigidbody

        }
    }
}
