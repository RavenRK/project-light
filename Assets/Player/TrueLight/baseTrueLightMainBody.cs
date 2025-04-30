using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class baseTrueLightMainBody : MonoBehaviour
{
    #region <_TrueLight settings >
    [Header("TrueLight settings")]
    public float orbitSpeed = 10f;         // Speed of the orbit
    public float projectileForce = 10f;    // Speed of the projectile
    //public float AtuoRecallTimer = 2.5f;     // Time to auto recall the projectile

    [Header("Transform settings")]
    public Transform originLocation;       //attack point and recall point for projectile
    public Transform forwardDir;           // Direction of the projectile should go

    [Header("Prefab settings")]
    public GameObject projectilePrefab;   // Prefab of the projectile
    public GameObject pointLight;         // Reference to the point light object
    private GameObject projectile;        // Reference to the projectile object

    private Rigidbody rb;
    private Renderer Renderer;             // Reference to the renderer component
    public bool CanFire = true;           // Check if the projectile can be fired
    #endregion
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>(); // Get the renderer component
    }
    private void FixedUpdate() { orbit(orbitSpeed); }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && CanFire)
        {
            projectile = Instantiate(projectilePrefab, originLocation.position, originLocation.rotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(forwardDir.forward * projectileForce, ForceMode.Impulse);
            SetState(false);
            //StartCoroutine(AutoRecall());
        }
    }
    /*IEnumerator AutoRecall()
    {
        yield return new WaitForSeconds(AtuoRecallTimer);                   // Wait for the specified time
        projectile.GetComponent<LightProJ>().StartRecall(this.transform);   // pass player position
    }*/
    public void OnRecall(InputAction.CallbackContext context)
    {
        if (context.performed)
            projectile.GetComponent<LightProJ>().StartRecall(this.transform); // pass player position

        //StopCoroutine(AutoRecall());
    }
    private void OnTriggerEnter(Collider other)
    {
        LightProJ proj = other.GetComponent<LightProJ>();
        if (proj.IsRecalling())
        {
            SetState(true);               // Enable the TrueLight when the projectile is recalled
            proj.CompleteRecall();
        }
    }

    public void OnRecall() { SetState(true); }
    public void SetState(bool state)
    {
        Renderer.enabled = state;        // Enable the renderer of the TrueLight
        pointLight.SetActive(state);     // Enable the point light object
        CanFire = state;                 // Set the CanFire flag to true to allow firing again
    }
    void orbit(float speed)
    {
        transform.Rotate(speed * Time.deltaTime, 0, speed * Time.deltaTime); // Rotate around the target point
    }

}
