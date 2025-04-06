using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement_Player : MonoBehaviour
{
    [Header("Player settings")]
    private float moveSpeed = 6;
    public float RunSpeed = 12f;
    public float WalkSpeed = 6f;
    public Transform playerCamera;
    private Vector2 moveInput;

    private Rigidbody rb;
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
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        // Get the input value from the contextand store in moveInput
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.performed)
            moveSpeed = RunSpeed;                                                                      // Increase the move speed when running
        else if (context.canceled)
            moveSpeed = WalkSpeed;                                                                       // Reset the move speed when not running
    }
}
