using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour,ISavevable
{

    private const float EXP_VALUE = 100;

    [SerializeField]
    private Text text_1;

    [SerializeField]
    private Text text_2;

    [SerializeField]
    private Image circle_1;

    [SerializeField]
    private Image circle_2;

    [SerializeField]
    private GameObject smallEnemy;

    [SerializeField]
    private GameObject bigEnemy;

    private int level;

    private float currentExp;

    private float totalXPToReachLevel;

    [SerializeField]
    private Slider exp;

    private ObjectPooler objectPooler;

    private GameObject skillChooser;

    private static bool isSave = false;


    private void Awake()
    {
        skillChooser = GameObject.FindGameObjectWithTag("Skill Chooser");
        skillChooser.SetActive(false);
    }

    private void Start()
    {
        if (!isSave)
        {
            level = 1;
            currentExp = 0;
        }
        text_1.text = this.level.ToString();
        text_2.text = (this.level + 1).ToString();
        exp.value = currentExp;
        objectPooler = ObjectPooler.Instance;
        totalXPToReachLevel = TotalXPToReachLevel(level);
        exp.maxValue = totalXPToReachLevel;
    }

    public void LevelUp(float expValue)
    {
        currentExp += expValue;
        exp.value = currentExp;
        if (currentExp >= totalXPToReachLevel)
        {
            ++level;
            currentExp -= totalXPToReachLevel;
            exp.value = currentExp;
            totalXPToReachLevel = TotalXPToReachLevel(level);
            exp.maxValue = totalXPToReachLevel;
            UpdateLevel(level);
        }
    }

    private void UpdateLevel(int level)
    {
        if(level % 2 == 0)
        {
            smallEnemy.GetComponent<Enemy>().enemyData.Speed += (smallEnemy.GetComponent<Enemy>().enemyData.Speed * 2) / 100;
            bigEnemy.GetComponent<Enemy>().enemyData.Speed += (bigEnemy.GetComponent<Enemy>().enemyData.Speed * 2) / 100;
        }
        StartCoroutine(ChooseSkill());
        this.level = level;
        text_1.text = this.level.ToString();
        text_2.text = (this.level + 1).ToString();
        for(int i = 0; i < objectPooler.pools.Count - 1; i++)
        {
            objectPooler.pools[i].maxSize += (objectPooler.pools[i].maxSize * 5) / 100;
        }
    }

    private IEnumerator ChooseSkill()
    {
        skillChooser.GetComponent<SkillChooser>().ChooseSkill();
        yield return null;
    }

    private float TotalXPToReachLevel(float level)
    {
        return (EXP_VALUE * level * (level + 1)) / 2;
    }

    public object SaveState()
    {
        isSave = true;
        return new LevelData()
        {
            level = this.level,
            currentExp = this.currentExp,
        };
    }

    public void LoadState(object state)
    {
        var data = (LevelData)state;
        this.level = data.level;
        this.currentExp = data.currentExp;
    }

    [System.Serializable]
    private struct LevelData
    {
        public int level;

        public float currentExp;

    }
}
