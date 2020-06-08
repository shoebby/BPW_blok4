using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class aberrationIncrease : MonoBehaviour
{
    float targetChromaticIntensityUpper = 2f;
    float targetChromaticIntensityLower = 0f;
    float currentChromaticIntensity = 0f;

    ChromaticAberration chromatic;
    PostProcessVolume volumeChromatic;

    void Start()
    {
        chromatic = ScriptableObject.CreateInstance<ChromaticAberration>();
        chromatic.enabled.Override(true);
        chromatic.intensity.Override(currentChromaticIntensity);
        volumeChromatic = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, chromatic);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (chromatic.intensity.value < targetChromaticIntensityUpper)
            {
                chromatic.intensity.value += 0.005f;
            }
            currentChromaticIntensity = targetChromaticIntensityLower;
        }
        else
        {
            chromatic.intensity.value = 0f;
        }
    }
}
