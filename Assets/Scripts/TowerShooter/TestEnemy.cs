using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
   public int health = 100;
   public AudioClip soundFX;
   
   public void TakeDamage(int damage) {
      health -= damage;
      if (health <= 0) {
         Die();
      }
   }

   private void Die() {
      AudioSource.PlayClipAtPoint(soundFX, transform.position);
      Destroy(gameObject);
   }
}
