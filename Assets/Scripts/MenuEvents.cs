using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public void LoadGame(int index)
    {
        SceneManager.LoadScene(index);
    }

}
