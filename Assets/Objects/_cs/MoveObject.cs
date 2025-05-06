using UnityEngine;

public class MoveObject : BasePowerUser
{
    [Header("Move Settings")]
    public Vector3 moveOffset;
    public float moveSpeed = 2f;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition;
    }

    void Update()
    {
        if (base.isPowered)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isPowered = false;
            }
        }
    }
    public override void OnPowered() { targetPosition = originalPosition + moveOffset; base.isPowered = true; }
    public override void OffPowered() { targetPosition = originalPosition; isPowered = true; }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            Debug.Log("Player is now a child of the moving object");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}

