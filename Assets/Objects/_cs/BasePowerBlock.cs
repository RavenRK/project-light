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
        if (other.gameObject.CompareTag("lightProJ"))   //check if collode with lightProJ
        {
            foreach (GameObject obj in toPowerObjects)  //run all on power func useing the foreach loop 
            {
                BasePowerUser powerUser = obj.GetComponent<BasePowerUser>();
                if (powerUser != null)
                    powerUser.OnPowered();
            }
            //change mat form unpowered to powered
            var mats = GetComponent<MeshRenderer>().materials;  
            mats[1] = poweredMaterial;
            GetComponent<MeshRenderer>().materials = mats;
        }
    }
    //set base power timer
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("lightProJ"))
            StartCoroutine(Delay());
    }
    //set after the delay time the power will be off
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(BasePowerTime);
        foreach (GameObject obj in toPowerObjects)
        {
            BasePowerUser powerUser = obj.GetComponent<BasePowerUser>();
            if (powerUser != null)
                powerUser.OffPowered();
        }
        //change mat form powered to unpowered
        var mats = GetComponent<MeshRenderer>().materials;
        mats[1] = unpoweredMaterial;
        GetComponent<MeshRenderer>().materials = mats;
    }
}

