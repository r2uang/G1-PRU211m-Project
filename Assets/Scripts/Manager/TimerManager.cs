using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour,IDataPersitence
{

    public Text timerCounter;

    public float currentTime;
    public void LoadData(GameData gameData)
    {
        timerCounter.text = gameData.timeSuvivor;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.timeSuvivor = timerCounter.text;
    }


    // Start is called before the first frame update
    void Start()
    {
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
