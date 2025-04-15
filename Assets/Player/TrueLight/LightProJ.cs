using UnityEngine;

public class LightProJ : MonoBehaviour
{
    private Transform returnLocation;   // The location to return to
    private bool isRecalling = false;   // Check if the projectile is recalling
    public float recallSpeed = 10f;     // Speed of the recall

    private int bounceCount = 0;         // Count the number of bounces
    private int maxBounces = 3;            // Maximum number of bounces
    public PhysicsMaterial nonBouncyMaterial;

    private Rigidbody rb;
    void Awake() { rb = GetComponent<Rigidbody>(); }
    private void FixedUpdate()
    {
        if (isRecalling)
            transform.position = Vector3.MoveTowards(transform.position, returnLocation.position, recallSpeed * Time.deltaTime);
    }

    public void StartRecall(Transform target)
    {
        returnLocation = target;            // Set the return location to the target
        isRecalling = true;                 // Set the recalling flag to true

        rb.isKinematic = true;              // Disable physics if needed
        rb.linearVelocity = Vector3.zero;   // Stop the projectile
    }
    public void CompleteRecall()
    {
        isRecalling = false;
        Destroy(gameObject);
    }
    public bool IsRecalling() => isRecalling;
    void OnCollisionEnter(Collision collision)
    {
        bounceCount++;
        if (bounceCount >= maxBounces)
            GetComponent<Collider>().material = nonBouncyMaterial;
    }
}
