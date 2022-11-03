using UnityEngine;

public class MusicControllScript : MonoBehaviour
{
    private static MusicControllScript instance;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
