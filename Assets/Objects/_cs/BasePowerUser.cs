using UnityEngine;

public class BasePowerUser : MonoBehaviour
{
    //base class for all power users with overrloadable methods for power on and off
    protected int PoweredObj = 0;
    public int powerNeeded = 1;
    void Start() { }
    void Update() { }
    public virtual void OnPowered() { Debug.Log("Power is activated"); }
    public virtual void OffPowered() { Debug.Log("Power is deactivated"); }
}
