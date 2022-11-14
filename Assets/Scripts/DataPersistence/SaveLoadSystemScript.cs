using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadSystemScript : MonoBehaviour
{
    public static string SavePath => $"{Application.persistentDataPath}/save.txt";

    public void Save()
    {
        var state = LoadFile();
        SaveState(state);
        SaveFile(state);
    }
    public void Load()
    {
        var state = LoadFile();
        LoadState(state);
    }


    void SaveFile(object state)
    {
        using (var stream = File.Open(SavePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    Dictionary<string, object> LoadFile()
    {
        if (!File.Exists(SavePath))
        {
            return new Dictionary<string, object>();
        }

        using (var stream = File.Open(SavePath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>)formatter.Deserialize(stream);
        }
    }


    void SaveState(Dictionary<string, object> state)
    {
        Debug.Log(FindObjectsOfType<SaveableEntity>().Length);
        foreach (var saveable in FindObjectsOfType<SaveableEntity>())
        {
            state[saveable.Id] = saveable.SaveState();
        }
    }

    void LoadState(Dictionary<string, object> state)
    {

        foreach (var saveable in FindObjectsOfType<SaveableEntity>())
        {
            if (state.TryGetValue(saveable.Id, out object savedState))
            {
                saveable.LoadState(savedState);
            }
        }
    }
}
