using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool _toggleMusic, _toggleEffects, _unToggleEffects;
    private AudioClip audioClipclip;

    public void Toggle(AudioClip audioClip)
    {
        if (_toggleEffects)
        {
            SoundManager.instance.ToggleEffects();
        }
        if (_unToggleEffects)
        {
            SoundManager.instance.UnToggleEffects(audioClipclip);
        }
        if (_toggleMusic)
        {
            SoundManager.instance.ToggleMusic();
        }
    }
}
