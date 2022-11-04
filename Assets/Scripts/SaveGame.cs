using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    public void Confirm()
    {
       DataPersistenceManager.instance.SaveGame();
       SceneManager.LoadSceneAsync("Menu Scene",LoadSceneMode.Single);
    }
}
