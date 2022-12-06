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
    public float attackspeed;//continuously deals damage.

    [SerializeField]
    EnemySO enemyinfo;

    [SerializeField]
    HealthBar healthbar;

    [SerializeField]
    bool isAttacking;
    [SerializeField]
    NumbersCanvas NUMBERSCANVAS;
    Player player; //is referenced when we collide with player and continue to attack it.

    public delegate void AddCoins(int amount);
    public static event AddCoins OnAddCoins;
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
           healthbar = GetComponentInChildren<HealthAnchor>().GetHealthBar();
        }
        isAttacking = false;

        if (NUMBERSCANVAS == null)
        {
            NUMBERSCANVAS = GameObject.FindObjectOfType<NumbersCanvas>();
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
        attackspeed = info.attackspeed;
    }

    public void DefaultSetUp()
    {
        enemyname = "Unnamed Enemy";
        coinsDropped = 0;
        damage = 0;
        maxHealth = 100;
        currenthealth = maxHealth;
        speed = 1;
        attackspeed = 1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if it interacts with a player, deal damage
        //if it is a bullet, it will receive damage.
       

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("I've hit player!");
            player = collision.gameObject.GetComponent<Player>();
            isAttacking = true;
            StartCoroutine("Attacking");
            // destory this gameobject 
            DestroyThisObject();
        }
    }

    public void DestroyThisObject()
    {
        GameObject.Destroy(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("taking 10 damage!");
            TakeDamage(10);
        }
    }
    public int DealDamage()
    {
        return damage;
    }

    public void TakeDamage(int damageDealt)
    {
        NUMBERSCANVAS.CreateTakeDamage(this.transform,damageDealt);
        currenthealth -= damageDealt;
       

        if (currenthealth <= 0)
        {
            Die();
        }
      
        float percentage = (float)currenthealth / (float)maxHealth;
        if (healthbar == null)
        {
            healthbar = GetComponentInChildren<HealthAnchor>().GetHealthBar();
        }
        healthbar.SetNextPercent(percentage);

    }

    IEnumerator Attacking()
    {
        while(isAttacking == true)
        {
            Attack();
            yield return new WaitForSeconds(attackspeed);
        }
        yield return new WaitForSeconds(attackspeed);
    }
    public void Die()
    {
        DropCoins();
        Destroy(gameObject);
    }

    void Attack()
    {
        if (player != null)
        {
            player.TakeDamage(damage);

            float x = player.transform.position.x + this.transform.position.x;
            float y = player.transform.position.y + this.transform.position.y;
            float z = player.transform.position.z + this.transform.position.z;
            x = x / 2f;
            y = y / 2f;
            z = z / 2f;
            Vector3 midpoint = new Vector3(  x,y,z );
            //NUMBERSCANVAS.CreateAttackText(this.transform, damage);
            NUMBERSCANVAS.CreateAttackText(midpoint, damage);
        }
        
    }

    public void DropCoins()
    {
        Debug.Log("I drop.." + coinsDropped);
        NUMBERSCANVAS.CreateCoinText(this.transform, coinsDropped);
        //now you die after dropping the coins.
        OnAddCoins(coinsDropped);
    }
}
