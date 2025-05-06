using UnityEngine;

public class BasePowerUser : MonoBehaviour
{
    public bool isPowered = false;
    void Start() { }
    void Update() { }
    public virtual void OnPowered() { Debug.Log("Power is activated"); }
    public virtual void OffPowered() { Debug.Log("Power is deactivated"); }
}
