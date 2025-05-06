using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BaseLight : BasePowerUser
{
    private Light lightSource;
    [Header("mat settings ")]
    public Material poweredMaterial;
    public Material unpoweredMaterial;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        lightSource = GetComponentInChildren<Light>();
        lightSource.enabled = false;
    }
    public override void OnPowered()
    {
        lightSource.enabled = true;
        GetComponentInChildren<MeshRenderer>().material = poweredMaterial;
    }
    public override void OffPowered() { }
}
