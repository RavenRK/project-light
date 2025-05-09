using NUnit.Framework.Constraints;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveObject : BasePowerUser
{
    [Header("Move Settings")]
    public float moveSpeed = 2f;
    public Vector3 targetPosition;
    public GameObject Player;

    private Vector3 originalPosition;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    void Update()
    {
        if (PoweredObj >= powerNeeded)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else if (originalPosition != transform.position && PoweredObj != powerNeeded)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
        }

    }

    public override void OnPowered() {PoweredObj += 1; }
    public override void OffPowered() {PoweredObj -= 1; }
}

