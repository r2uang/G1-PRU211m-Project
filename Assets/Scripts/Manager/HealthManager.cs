using UnityEngine;

public class HealthManager : MonoBehaviour, ISavevable
{
    private Player player;
    public float currentHealth;
    public float maxHealth;
    private float timeToHealth;
    public float saveTimeToHealth;
    public bool isRegen = false;
    public static bool isSave = false;



    // Start is called before the first frame update
    void Start()
    {
        SkillManager.instance.healthManager = this;
        timeToHealth = 3f;
        player = GetComponent<Player>();
        if (!isSave)
        {
            maxHealth = player.playerData.HP;
            currentHealth = player.playerData.HP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.timeToHealth -= Time.deltaTime;
        if (isRegen)
        {
            Regen();
        }
    }

    public void Regen()
    {
        if (this.timeToHealth <= 0 && currentHealth <= maxHealth)
        {
            currentHealth += player.playerData.percentRegenHP;
            this.timeToHealth = saveTimeToHealth;
        }
    }

    public void HurtPlayer(float damageReceive)
    {
        currentHealth -= damageReceive - player.playerData.armor;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            PlayerManager.isGameOver = true;
        }
    }

    public object SaveState()
    {
        isSave = true;
        return new HealthData()
        {
            currentHealth = this.currentHealth,
            maxHealth = this.maxHealth
        };
    }

    public void LoadState(object state)
    {
        var data = (HealthData)state;
        currentHealth = data.currentHealth;
        maxHealth = data.maxHealth;
    }

    [System.Serializable]
    private struct HealthData
    {
        public float currentHealth;
        public float maxHealth;
    }
}
