using UnityEngine;
using UnityEngine.InputSystem;
public class Player_BaseMovement : MonoBehaviour
{
/*    InputAction move_Action;
    InputAction jump_Action;
    InputAction Look_Action;*/

    private Vector2 m_Position;
    private float move_Speed;
    private float jump_Power;

    public LayerMask lightHitLayer;
    public int rayLength;
    public GameObject connectionPoint;

    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
/*        move_Action = InputSystem.actions.FindAction("Move");
        jump_Action = InputSystem.actions.FindAction("Jump");*/

    }
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayLength, lightHitLayer))
        {
            hit.transform.GetComponent<LightIneract>().HitByLight();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayLength, Color.yellow);
            lineRenderer.SetPosition(1,hit.point);
            lineRenderer.SetPosition(0,transform.position);
        }
        else
        {
            lineRenderer.SetPosition(1, transform.position);
            lineRenderer.SetPosition(0, transform.position);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayLength, Color.red);
        }



    }
    //public void OnMove

}
