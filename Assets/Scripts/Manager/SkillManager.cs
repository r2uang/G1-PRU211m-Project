using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public Skill[] skills;
    public SkillButton[] skillButtons;
    public Skill activeSkill;
    private SkillChooser skillChooser;
    public Player player;
    public HealthManager healthManager;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(instance);
    }

    private void Start()
    {
        skillChooser = gameObject.GetComponent<SkillChooser>();
        
    }

    private void Update()
    {
        UpdateSkillImage();
    }

    private void UpdateSkillImage()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].isUpgrade)
            {
                skills[i].GetComponent<Image>().color = new Vector4(255, 22, 0, 255);
            }
        }
    }

    public void UpdateButton()
    {
        if(activeSkill == null)
        {
            skillButtons[1].skillDesc.text = $"!!!Please choose one skill to upgrade!!!";
            return;
        }
        if(activeSkill.numberOfChoose <= 3)
        {
            activeSkill.numberOfChoose += 1;
            UpdateSkill(activeSkill.skillName);
            activeSkill.stars[activeSkill.numberOfChoose - 1].SetActive(true);
            skillChooser.Resume();
            activeSkill = null;
        }
        else
        {
            skillButtons[1].skillDesc.text = $"Skil {activeSkill.skillName} is already upgraded!!";
        }
    }

    private void UpdateSkill(string name)
    {
        switch (name)
        {
            case "Speed Up":
                player.playerData.speed += ((player.playerData.speed * 10) / 100);
                Debug.Log("Upgrades");
                break;
            case "Up Health":
                player.playerData.HP += 50;
                Debug.Log("Upgrades");
                break;
            case "Increase Armour":
                player.playerData.armor += 5;
                Debug.Log("Upgrades");
                break;
            case "Rapid Fire":
                player.FireRate -= (player.FireRate * 10) / 100;
                Debug.Log("Upgrades");
                break;
            case "Bullet Hell":
                player.isFireBulletHell = true;
                if (activeSkill.numberOfChoose == 1)
                {
                    player.saveTimeToFireBulletHell = 6f;
                    player.gunLength = 2;
                }
                else if (activeSkill.numberOfChoose == 2)
                {
                    player.saveTimeToFireBulletHell = 4f;
                    player.gunLength = 3;
                }
                else
                {
                    player.saveTimeToFireBulletHell = 3f;
                    player.gunLength = 4;
                }
                Debug.Log("Upgrades");
                break;
            case "Regen":
                healthManager.isRegen = true;
                if (activeSkill.numberOfChoose == 1)
                {
                    healthManager.saveTimeToHealth = 10f;
                }
                else if (activeSkill.numberOfChoose == 2)
                {
                    healthManager.saveTimeToHealth = 7f;
                }
                else
                {
                    healthManager.saveTimeToHealth = 5f;
                }
                Debug.Log("Upgrades");
                break;
        }
    }
}
