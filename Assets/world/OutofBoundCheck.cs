using Unity.VisualScripting;
using UnityEngine;

public class OutofBoundCheck : MonoBehaviour
{
    public GameObject PlayerPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lightProJ"))
            other.GetComponent<LightProJ>().StartRecall(PlayerPosition.transform); // pass player position
    }
}
