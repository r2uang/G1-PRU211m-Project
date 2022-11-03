using System.Collections.Generic;
using System.Linq;
using UnityEngine;


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
    }

    public void LoadGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }
        foreach (IDataPersitence dataPersitenceObj in dataPersitenceObjects)
        {
            dataPersitenceObj.LoadData(gameData);
        }

    }

    public void SaveGame()
    {
        foreach (IDataPersitence dataPersitenceObj in dataPersitenceObjects)
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
