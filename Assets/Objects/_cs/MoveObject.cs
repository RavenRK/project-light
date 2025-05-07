using UnityEditor.Rendering;
using UnityEngine;

public class MoveObject : BasePowerUser
{
    [Header("Move Settings")]
    public Vector3 moveOffset;
    public float Xmove, Zmove;
    public float moveSpeed = 2f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private Rigidbody collidingObject = null;
    private Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
        targetPosition = originalPosition;
    }

    void Update()
    {
        if (base.PoweredObj == base.powerNeeded)
        {
            // rb.linearVelocity = new Vector3(Xmove,0,Zmove);
            transform.position += new Vector3(Xmove, 0, Zmove) * Time.deltaTime ;

            Debug.Log(collidingObject);

            if (collidingObject != null)
            {
                collidingObject.GetComponent<movementPlayer>().UpdateIsMoving(new Vector3(Xmove, 0, Zmove));
                collidingObject.linearVelocity = new Vector3(Xmove, 0, Zmove);
            }

        }
        else if(collidingObject != null)
            collidingObject.GetComponent<movementPlayer>().UpdateIsMoving(new Vector3(0, 0, 0));
    }
    public override void OnPowered() { targetPosition = originalPosition + moveOffset; base.PoweredObj += 1; }
    public override void OffPowered() { targetPosition = originalPosition; PoweredObj = 0; }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collidingObject = collision.GetComponent<Rigidbody>();
            //collision.transform.SetParent(transform);
            //Debug.Log("Player is now a child of the moving object");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
            //collision.transform.SetParent(null);
    }
}

