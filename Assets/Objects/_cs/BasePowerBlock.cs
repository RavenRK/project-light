using System.Collections;
using UnityEngine;

public class basePower : MonoBehaviour
{
    public float BasePowerTime;

    [Header("Objects to Power")]
    public GameObject[] toPowerObjects;

    [Header("mat settings ")]
    public Material poweredMaterial;
    public Material unpoweredMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("lightProJ"))
        {
            foreach (GameObject obj in toPowerObjects)
            {
                BasePowerUser powerUser = obj.GetComponent<BasePowerUser>();
                if (powerUser != null)
                {
                    powerUser.OnPowered();
                    powerUser.isPowered = true;
                }
            }
            var mats = GetComponent<MeshRenderer>().materials;
            mats[1] = poweredMaterial;
            GetComponent<MeshRenderer>().materials = mats;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("lightProJ"))
        {
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(BasePowerTime);

        foreach (GameObject obj in toPowerObjects)
        {
            BasePowerUser powerUser = obj.GetComponent<BasePowerUser>();
            if (powerUser != null)
            {
                powerUser.OffPowered();
                powerUser.isPowered = true;
            }
        }
        var mats = GetComponent<MeshRenderer>().materials;
        mats[1] = unpoweredMaterial;
        GetComponent<MeshRenderer>().materials = mats;
    }
}

