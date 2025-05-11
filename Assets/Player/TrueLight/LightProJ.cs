using System.Collections;
using UnityEngine;

public class LightProJ : MonoBehaviour
{
    public float recallSpeed = 5;       // Speed of the recall
    public GameObject miniLight;        // Reference to the mini light prefab
    public GameObject HitVFX;           // Reference to the mini light prefab

    public float AutoRecallTimer = 2.5f;
    public PhysicsMaterial nonBouncyMaterial;

    private Transform returnLocation;   // The location to return to
    private bool isRecalling = false;   // Check if the projectile is recalling
    private Rigidbody rb;

    void Awake() { rb = GetComponent<Rigidbody>(); }    // Get the rigidbody component
    private void FixedUpdate()
    {
        if (isRecalling)    // Move towards the return location (player)
            transform.position = Vector3.MoveTowards(transform.position, returnLocation.position, recallSpeed * Time.deltaTime); 
    }

    public void StartRecall(Transform target)
    {
        returnLocation = target;            // Set the return location to the target
        isRecalling = true;                 // Set the recalling flag to true
        rb.isKinematic = true;              // Disable physics
    }
    public void CompleteRecall()
    {
        isRecalling = false;    // Set the recalling flag to false
        Destroy(gameObject);    // Destroy the projectile
    }
    public bool IsRecalling() => isRecalling;   // Check if the projectile is recalling 
    void OnCollisionEnter(Collision collision) 
    {
        // Get the contact point
        Vector3 spawnPoint = collision.contacts[0].point;

        // Spawn mini light and VFX at the contact point
        GameObject mini = Instantiate(miniLight, spawnPoint, Quaternion.identity);
        GameObject VFX = Instantiate(HitVFX, spawnPoint, Quaternion.identity);

    }
}
