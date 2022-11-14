using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAudioManager : MonoBehaviour
{
    public static AudioClip fire;
    public static AudioSource audioSource;

    private void Start()
    {
        fire = Resources.Load<AudioClip>("fire");
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "fire":
                audioSource.PlayOneShot(fire);
                break;
        }
    }
}
