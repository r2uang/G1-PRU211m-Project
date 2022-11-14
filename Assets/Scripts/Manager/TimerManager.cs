using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour,ISavevable
{

    public Text timerCounter;

    public float currentTime;

    public void LoadState(object state)
    {
        currentTime = (float)state;
    }

    public object SaveState()
    {
        return currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");
        timerCounter.text = "Time: " + String.Format("{0}:{1}", minutes, seconds);
    }
}
