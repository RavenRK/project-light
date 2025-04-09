using UnityEngine;
using UnityEngine.InputSystem;

public class Base_TrueLight : MonoBehaviour
{
    [Header("TrueLight settings")]
    public float orbitSpeed = 10f;         // Speed of the orbit
    public float AttackPower = 10f;         // Attack power << throw power >>
    public Transform playerCamera;
    public Transform originLocation;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

    }
    private void FixedUpdate()
    {
        orbit(orbitSpeed);
    }
    void orbit(float speed)
    {
        transform.Rotate(speed * Time.deltaTime, 0, speed * Time.deltaTime); // Rotate around the target point
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 forward = playerCamera.forward;                                                      // Get the forward and right vectors of the camera
            rb.AddForce(forward * AttackPower, ForceMode.Impulse);        // Apply force to the TrueLight
        }
    }
    public void OnRecall(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.position = originLocation.position;         // Recall the TrueLight to its original location
            rb.linearVelocity = Vector3.zero;                     // Stop the TrueLight
        }
    }
}
