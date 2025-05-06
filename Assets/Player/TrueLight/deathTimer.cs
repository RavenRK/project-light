using UnityEngine;

public class deathTimer : MonoBehaviour
{
    public float destroyAfter = 2f; // Set time in seconds
    void Start() { Destroy(gameObject, destroyAfter); }
}
