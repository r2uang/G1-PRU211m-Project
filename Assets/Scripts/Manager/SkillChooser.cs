using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChooser : MonoBehaviour
{

    public GameObject UI_ChooseSkill;  

    public void Resume()
    {
        UI_ChooseSkill.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ChooseSkill()
    {
        UI_ChooseSkill.SetActive(true);
        Time.timeScale = 0f;
    }
}
