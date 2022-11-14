using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField]
    AudioSource music;

    public void OnMusic()
    {
        music.Play();
    }

    public void OffMusic()
    {
        music.Stop();
    }
}
