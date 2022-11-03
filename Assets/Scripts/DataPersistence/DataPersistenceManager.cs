using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;

    private List<IDataPersitence> dataPersitenceObjects;
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {

        instance = this;
    }
    private void Start()
    {
        this.dataPersitenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }
        foreach(IDataPersitence dataPersitenceObj in dataPersitenceObjects)
        {
            dataPersitenceObj.LoadData(gameData);
        }
        Debug.Log("Loaded Time Survivor = " + gameData.timeSuvivor);
    }

    public void SaveGame()
    {
        foreach(IDataPersitence dataPersitenceObj in dataPersitenceObjects)
        {
            dataPersitenceObj.SaveData(ref gameData);
        }
        Debug.Log("Saved death count = " + gameData.timeSuvivor);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersitence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersitence> dataPersitenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersitence>();

        return new List<IDataPersitence>(dataPersitenceObjects);
    }
}
