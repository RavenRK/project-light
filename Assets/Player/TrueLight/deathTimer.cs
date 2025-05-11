using UnityEngine;

public class deathTimer : MonoBehaviour
{
    public float destroyAfter = 2f; // Set time in seconds and destroy the object self
    void Start() { Destroy(gameObject, destroyAfter); }
}
