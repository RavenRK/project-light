using System.Collections;
using UnityEngine;

public class basePower : MonoBehaviour
{
    public float BasePowerTime;

    public GameObject toPowerObjectRef; // Reference to the object to power
    public Material poweredMaterial;    // Material to apply when powered
    public Material unpoweredMaterial;  // Material to apply when unpowered
    private void Awake()
    {
    }
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lightProJ"))
        {
            BasePowerUser powerUser = toPowerObjectRef.GetComponent<BasePowerUser>();

            GetComponent<MeshRenderer>().material = poweredMaterial;
            powerUser.OnPowered();
            powerUser.isPowered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("lightProJ"))
            StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        {
            BasePowerUser powerUser = toPowerObjectRef.GetComponent<BasePowerUser>();

            yield return new WaitForSeconds(BasePowerTime);
            GetComponent<MeshRenderer>().material = unpoweredMaterial;
            powerUser.OffPowered();
            powerUser.isPowered = true;
        }
    }
}
