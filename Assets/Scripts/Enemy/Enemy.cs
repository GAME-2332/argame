using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    public string enemyname;
    [SerializeField]
    public int coinsDropped;
    [SerializeField]
    public int damage;
    [SerializeField]
    public int currenthealth;
    [SerializeField]
    public int maxHealth;
    [SerializeField]
    public float speed;

    [SerializeField]
    EnemySO enemyinfo;

    [SerializeField]
    HealthBar healthbar;

    private void Start()
    {
        if(enemyinfo != null)
        {
            SpawnByEnemyInfo(enemyinfo);
        }
        else
        {
            DefaultSetUp();
        }

        if(healthbar == null)
        {
            healthbar = GetComponentInChildren<HealthBar>();
        }

    }

    public void SpawnByEnemyInfo(EnemySO info)
    {
        enemyname = info.enemyname;
        coinsDropped = info.coinsDropped;
        damage = info.damage;
        maxHealth = info.maxHealth;
        speed = info.speed;
        currenthealth = maxHealth;
    }

    public void DefaultSetUp()
    {
        enemyname = "Unnamed Enemy";
        coinsDropped = 0;
        damage = 0;
        maxHealth = 100;
        currenthealth = maxHealth;
        speed = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if it interacts with a player, deal damage
        //if it is a bullet, it will receive damage.
        Debug.Log("ouch!");
        TakeDamage(Random.Range(30,80));
    }

    public void DealDamage()
    {

    }

    public void TakeDamage(int damageDealt)
    {
        currenthealth -= damageDealt;
       

        if (currenthealth <= 0)
        {
            Die();
        }
      
        float percentage = (float)currenthealth / (float)maxHealth;
        if (healthbar == null)
        {
            healthbar = GetComponentInChildren<HealthBar>();
        }
        healthbar.SetNextPercent(percentage);

    }

    public void Die()
    {
        DropCoins();
    }

    public void DropCoins()
    {
        Debug.Log("I drop.." + coinsDropped);
    }
}
