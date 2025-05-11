using UnityEngine;
using UnityEngine.InputSystem;

public class ProJControler : MonoBehaviour
{
    public float curveStrength = 50f;
    public float maxSpeed = 20f;

    private Rigidbody rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            //gide the object with the camera normal
            Vector3 camForward = mainCamera.transform.forward;
            rb.AddForce(camForward.normalized * curveStrength, ForceMode.Acceleration);

            // Clamp speed
            if (rb.linearVelocity.magnitude > maxSpeed)
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}
