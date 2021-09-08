using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    [SerializeField]
    private float timeReduction = 0.5f;

    // Enter time slow down mode - reduce in-game timescale by half
    public void SlowDownTime()
    {
        Debug.Log("Time slow down mode entered...");
        Time.timeScale = timeReduction;
    }

    // Set game timescale to normal value
    public void ResumeNormalTime()
    {
        Debug.Log("Time set to normal speed...");
        Time.timeScale = 1f;
    }

    void Update()
    {
        // If player presses return key, either slow down time or return time to normal value
        if (Input.GetKeyDown("return") & Time.timeScale == 1f)
        {
            SlowDownTime();
        }
        else if (Input.GetKeyDown("return") & Time.timeScale == timeReduction)
        {
            ResumeNormalTime();
        }
    }
}
