using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class VignetteController : MonoBehaviour
{
    public Volume volume;
    private Vignette vignette;
    public float flashDuration = 0.3f;

    void Start()
    {
        volume.profile.TryGet(out vignette);
    }

    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        vignette.intensity.value = 0.6f;

        yield return new WaitForSeconds(flashDuration);

        vignette.intensity.value = 0f;
    }
}