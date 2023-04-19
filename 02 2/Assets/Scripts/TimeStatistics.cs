using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStatistics : MonoBehaviour
{
    public float TotalTime
    {
        get
        {
            float totalTime = Time.realtimeSinceStartup;

            if (PlayerPrefs.HasKey("totalTime"))
                totalTime += PlayerPrefs.GetFloat("totalTime");

            return totalTime;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("totalTime", this.TotalTime);
    }
}
