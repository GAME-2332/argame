using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
   public GameObject enemyTarget;

   private void FixedUpdate()
   {
    
   }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
            Destroy(collision.gameObject);
   }
    
   
}
