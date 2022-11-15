using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    int maxhealth;
    [SerializeField]
    int currenthealth;
    [SerializeField]
    HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        if(maxhealth <= 0)
        {
            maxhealth = 500;
            currenthealth = maxhealth;
        }

        currenthealth = maxhealth;
        if (healthbar == null)
        {
            healthbar = GetComponentInChildren<HealthAnchor>().GetHealthBar();
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void TakeDamage(int damageReceived) //called by Enemy on its collision.
    {
        currenthealth -= damageReceived;
        if(currenthealth <= 0)
        {
            Die();
        }
        if (healthbar == null)
        {
            healthbar = GetComponentInChildren<HealthAnchor>().GetHealthBar();
        }
        float percentage = (float)currenthealth / (float)maxhealth;
        healthbar.SetNextPercent(percentage);
    }

    public void Die()
    {
        GameObject.Destroy(this.gameObject);
        //return to start menu.
    }
}
