using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BaseData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "DataManager/EnemyDataManager", order = 1)]
    public class EnemyDataManager : ScriptableObject
    {
        public string className;
        public string classDescription;

        public float HP;
        public float percentRegenHP = 0;
        public float armor;

        public float percentDamage = 0;
        public float meleeDamage;
        public float rangeDamage;
        public float elementDamage;
        public float percentLifeSteel = 0;
        public float attackRange = 0;
        public float range = 0;


        public float percentAttackSpeed = 0;
        public float Speed = 0;

        public float xpDrop = 0;
        public float percentExpGains = 0;
        public float percentCoinGains = 0;
    }
}
