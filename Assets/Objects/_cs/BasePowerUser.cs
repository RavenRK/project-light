using UnityEngine;

public class BasePowerUser : MonoBehaviour
{
    protected int PoweredObj = 0;
    public int powerNeeded = 1;
    void Start() { }
    void Update() { }
    public virtual void OnPowered() { Debug.Log("Power is activated"); }
    public virtual void OffPowered() { Debug.Log("Power is deactivated"); }
}
