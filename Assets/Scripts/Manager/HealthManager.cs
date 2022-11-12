using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private Player player;
    public float currentHealth;
    public float maxHealth;
    private float timeToHealth;
    public float saveTimeToHealth;
    public bool isRegen = false;
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        SkillManager.instance.healthManager = this;
        timeToHealth = 3f;
        player = GetComponent<Player>();
        maxHealth = player.playerData.HP;
        currentHealth = player.playerData.HP;
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
}
