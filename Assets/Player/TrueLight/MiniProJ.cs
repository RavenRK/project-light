using System.Collections;
using UnityEngine;

public class MiniProJ : MonoBehaviour
{
    //     on start, the light will fade out over a set duration
    public float fadeDuration = 2.5f;
    private Light pointLight;
    private void Awake() { pointLight = GetComponentInChildren<Light>(); }
    void Start() { StartCoroutine(FadeLight()); }
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

