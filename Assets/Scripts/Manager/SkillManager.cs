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
                skills[i].GetComponent<Image>().color = new Vector4(255, 255, 255, 56);
            }
        }
    }

    public void UpdateButton()
    {
        if(!activeSkill.isUpgrade)
        {
            activeSkill.isUpgrade = true;
            UpdateSkill(activeSkill.skillName);
            skillChooser.Resume();
        }
        else
        {
            Debug.Log($"Skil {activeSkill.skillName} is already upgraded!!");
        }
    }

    private void UpdateSkill(string name)
    {
        switch (name)
        {
            case "Speed Up":
                player.playerData.speed += (player.playerData.speed * 10) / 100;
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
                player.isRapidFire = true;
                player.saveTimeToRapidFire = 10f;
                Debug.Log("Upgrades");
                break;
            case "Bullet Hell":
                player.isFireBulletHell = true;
                player.saveTimeToFireBulletHell = 5f;
                Debug.Log("Upgrades");
                break;
            case "Regen":
                healthManager.isRegen = true;
                healthManager.saveTimeToHealth = 5f;
                player.gunLength = 3;
                Debug.Log("Upgrades");
                break;
        }
    }
}
