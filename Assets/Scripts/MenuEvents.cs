using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public void LoadGame(int index)
    {       
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

}
