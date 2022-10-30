using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChooser : MonoBehaviour
{

    public GameObject UI_ChooseSkill;  

    public bool IsChooseSkill { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (IsChooseSkill)
    //    {
    //        ChooseSkill();
    //    }
    //    else
    //    {
    //        Resume();
    //    }
    //}

    public void Resume()
    {
        UI_ChooseSkill.SetActive(false);
        Time.timeScale = 1f;
        IsChooseSkill = false;
    }

    public void ChooseSkill()
    {
        UI_ChooseSkill.SetActive(true);
        Time.timeScale = 0f;
        IsChooseSkill = true;
    }
}
