using System.Collections;
using UnityEngine;

public class MiniProJ : MonoBehaviour
{
    public float fadeDuration = 2.5f;
    public float randomForce = 3f;

    private Light pointLight;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pointLight = GetComponentInChildren<Light>();


        if (pointLight == null)
            Debug.LogError("MiniProJ: Point light not found!");
    }

    void Start()
    {
        rb.AddForce(Random.onUnitSphere * randomForce, ForceMode.Impulse);
        StartCoroutine(FadeLight());
    }
    private IEnumerator FadeLight()
    {
        float startIntensity = pointLight.intensity;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            pointLight.intensity = Mathf.Lerp(startIntensity, 0f, timer / fadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        pointLight.intensity = 0f;
        Destroy(gameObject);
    }
}

