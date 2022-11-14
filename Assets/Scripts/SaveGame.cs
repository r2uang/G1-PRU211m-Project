using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    public void Confirm()
    {
        GameObject.FindGameObjectWithTag("SaveLoad").GetComponent<SaveLoadSystemScript>().Save();
        SceneManager.LoadSceneAsync("Menu Scene",LoadSceneMode.Single);
    }
}
