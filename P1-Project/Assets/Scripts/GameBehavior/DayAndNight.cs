using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was copied from Zenva's minicourse - Create a Day and night cycle in Unity 
public class DayAndNight : MonoBehaviour
{
    // This defines the the range of the day and night from 0.0 to 1.0 in strenght
    [Range(0.0f, 1.0f)]
    public float time;
    public float fullDayLenght;
    // Start value for the time of day
    public float startTime = 0.4f;
    private float timeRate;
    public Vector3 noon;

    // The Header is from MonoBehavior which is unity's standard class. Thus light, gradient i.e. works and are shown in the inspector
    [Header("Sun")]
    public Light sun;
    public Gradient sunColour;
    public AnimationCurve sunIntensity;

    [Header("Moon")]
    public Light moon;
    public Gradient moonColour;
    public AnimationCurve moonIntensity;

    [Header("Other Lighting")]
    public AnimationCurve lightingIntensityMultiplier;
    public AnimationCurve reflectionsIntensityMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        timeRate = 1.0f / fullDayLenght;
        time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Increment time   
        time += timeRate * Time.deltaTime;

        if (time >= 1.0f)
            time = 0.0f;

        // Light rotation with offset 
        sun.transform.eulerAngles = (time - 0.25f) * noon * 4.0f;
        moon.transform.eulerAngles = (time - 0.75f) * noon * 4.0f;

        // light intensity 
        sun.intensity = sunIntensity.Evaluate(time);
        moon.intensity = moonIntensity.Evaluate(time);

        // Change colour 
        sun.color = sunColour.Evaluate(time);
        moon.color = moonColour.Evaluate(time);

        // enable / disable the sun
        if (sun.intensity == 0 && sun.gameObject.activeInHierarchy)
            sun.gameObject.SetActive(false);
        else if (sun.intensity > 0 && !sun.gameObject.activeInHierarchy)
            sun.gameObject.SetActive(true);

        // enable / disaable the moon
        if (moon.intensity == 0 & moon.gameObject.activeInHierarchy)
            moon.gameObject.SetActive(false);
        else if (moon.intensity > 0 && moon.gameObject.activeInHierarchy)
            moon.gameObject.SetActive(true);

        // Control Lighting and reflections multiplier 
        RenderSettings.ambientIntensity = lightingIntensityMultiplier.Evaluate(time);
        RenderSettings.reflectionIntensity = reflectionsIntensityMultiplier.Evaluate(time);
    }
}
