using UnityEngine;

[System.Serializable]
public class GameData
{
    public string timeSuvivor;
    public float currentHP;
    public float maxHP;

    public GameData()
    {
        this.timeSuvivor = "";
    }
}
