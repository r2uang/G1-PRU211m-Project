using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName;
    //public Sprite skillSprite;

    [TextArea(1,3)]
    public string skillDes;
    public int numberOfChoose = 0;
    public bool isUpgrade = false;

    public GameObject[] stars;
}
