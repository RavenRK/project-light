using UnityEngine;
using UnityEngine.InputSystem;

public class Base_TrueLight_MainBody : MonoBehaviour
{
    [Header("TrueLight settings")]
    public float orbitSpeed = 10f;         // Speed of the orbit
    public float AttackPower = 10f;        // Attack power << throw power >>
    public Transform originLocation;       //attack point and recall point for projectile

    public float projectileForce = 10f;    // Speed of the projectile
    public GameObject projectilePrefab;    // Prefab of the projectile

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
            GameObject proj = Instantiate(projectilePrefab, originLocation.position, originLocation.rotation);
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            rb.AddForce(originLocation.forward * projectileForce, ForceMode.Impulse);
        }
    }
    public void OnRecall(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //make vis
            //recall proj
            transform.position = originLocation.position;         // Recall the TrueLight to its original location
            rb.linearVelocity = Vector3.zero;                     // Stop the TrueLight
        }
    }
}
