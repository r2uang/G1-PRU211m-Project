using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Text skillDesc;

    public int skillButtonId;

    public void PressSkillButton()
    {
        SkillManager.instance.activeSkill = transform.GetComponent<Skill>();
        skillDesc.text = SkillManager.instance.skills[skillButtonId].skillDes;
    }
}
