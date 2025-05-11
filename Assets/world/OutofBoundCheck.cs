using Unity.VisualScripting;
using UnityEngine;

public class OutofBoundCheck : MonoBehaviour
{
    public GameObject PlayerPosition;       //ref to the player
    public Transform PlayerResapwnPoint;    //ref to the spawn point
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lightProJ"))
            other.GetComponent<LightProJ>().StartRecall(PlayerPosition.transform); // pass player position

        if (other.gameObject.CompareTag("Player"))
            other.transform.position = PlayerResapwnPoint.position; // teleport player to the spawn point
    }
}
