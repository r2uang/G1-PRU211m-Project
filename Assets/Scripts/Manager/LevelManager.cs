using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private static int xpIncrementPerLevel;
    private static int Level;
    private static int totalXPToReachLevel;
    private static int EXP_VALUE = 100;

    // Start is called before the first frame update
    void Start()
    {
        xpIncrementPerLevel = 0;
        Level = 1;
        totalXPToReachLevel = TotalXPToReachLevel(Level);
    }

    // Update is called once per frame

    public static void LevelUp(int value)
    {
        Debug.Log("Level: " + Level);
        xpIncrementPerLevel += value;
        Debug.Log("Xp " + xpIncrementPerLevel);
        if (xpIncrementPerLevel >= totalXPToReachLevel)
        {
            ++Level;
            xpIncrementPerLevel -= value;
            totalXPToReachLevel = TotalXPToReachLevel(Level);
        }
    }

    private static int TotalXPToReachLevel(int level)
    {
        return EXP_VALUE * level * (level + 1) / 2;
    }
}
