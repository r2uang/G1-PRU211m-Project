using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider _slider;
    void Start()
    {
        _slider.onValueChanged.AddListener(val => SoundManager.instance.ChangeMasterVolume(val));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
