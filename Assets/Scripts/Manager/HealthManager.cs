using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private Player player;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float timeToHealth = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        maxHealth = player.playerData.HP;
        currentHealth = player.playerData.HP;
    }

    // Update is called once per frame
    void Update()
    {
        timeToHealth -= Time.deltaTime;
        if(timeToHealth <= 0 && currentHealth <= maxHealth)
        {
            currentHealth += player.playerData.percentRegenHP;
            timeToHealth = 5f;
        }
    }
    public void HurtPlayer(float damageReceive)
    {
        currentHealth -= damageReceive - player.playerData.armor;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
