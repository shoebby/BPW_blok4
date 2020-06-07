using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{
    public float slowdownFactor;
    public float slowdownLength;

    private void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
    public void doSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}