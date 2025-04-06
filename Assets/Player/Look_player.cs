using UnityEngine;
using UnityEngine.InputSystem;

public class Look_player : MonoBehaviour
{
    public Transform playerBody;

    public float mouseSensitivity = 100f;
    private Vector2 lookInput;
    private float xRotation = 0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;                           // Lock the cursor to the center of the screen
    }
    void Update()
    {
        
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;     // Get the mouse input and apply sensitivity
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;                                                // Rotate the camera and player body based on mouse input
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);                      // Clamp the xRotation to prevent flipping
       
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);      // Apply the rotation to the camera
        playerBody.Rotate(Vector3.up * mouseX);                             // Rotate the player body around the y-axis
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        // Get the input value from the context and store in lookInput
        lookInput = context.ReadValue<Vector2>();
    }
}
