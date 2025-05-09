using Unity.VisualScripting;
using UnityEngine;

public class OutofBoundCheck : MonoBehaviour
{
    public GameObject PlayerPosition;
    public Transform PlayerResapwnPoint;
    private Vector3 playerRespawnPiont;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lightProJ"))
            other.GetComponent<LightProJ>().StartRecall(PlayerPosition.transform); // pass player position

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player out of bounds");
            other.transform.position = PlayerResapwnPoint.position; // teleport player to the spawn point
        }
    }
}
