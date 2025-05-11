using UnityEngine;

public class MoveObject : BasePowerUser
{
    [Header("Move Settings")]
    public float moveSpeed = 2f;
    public Vector3 targetPosition;
    public GameObject Player;
    public bool moveback = true;

    private Vector3 originalPosition;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;  //get original position of the object
    }
    void Update()
    {
        if (PoweredObj >= powerNeeded) //if the object is powered
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime); //move to target position
        else if (originalPosition != transform.position && PoweredObj != powerNeeded && moveback == true) //check if the object is at original position check if the object is not powered and if can move back
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime); //move back to original position
    }
    public override void OnPowered() {PoweredObj += 1; }    //add 1 to the powered objects on power on
    public override void OffPowered() {PoweredObj -= 1; }   //remove 1 from the powered object on power off
}

