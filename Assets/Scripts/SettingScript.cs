using UnityEngine;

public class SettingScript : MonoBehaviour
{
    public GameObject settingScreen;

    public void OpenSetting()
    {
        settingScreen.SetActive(true);
    }
}
