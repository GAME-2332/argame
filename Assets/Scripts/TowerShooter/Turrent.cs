using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class Turrent : MonoBehaviour
{

    private Transform target;

     [Header("Audio")] 
     public AudioClip soundFX;
    
    
    
    [Header("Attributes")]
    
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    
    [Header(("Unity Setup Fields"))]
    
    public string enemyTag = "Enemy";

    public Transform turrentBase;
    public float turrentSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform explodePos;

     public GameObject explosionFX;
    
    
    // void Start() {
    //     //Repeats called method
    //     InvokeRepeating("UpdateTarget", 0f, 0.5f);
    // }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            //Gets distance to that enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //finds enemy closer to any you have found previously 
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //if turrent found nearest enemy, found enemy within range, sets target to enemies transform
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }else{
            target = null;
        }
    }

    void Update(){
        UpdateTarget();
        if (target == null)
            return;
        
       //Target Lock on
       // Vector3 direction = target.position - transform.position;
       // Quaternion lookRotate = Quaternion.LookRotation(direction);
       //When turrent looks at new enemy, it smoothly turns to the new enemy, instead of snapping 
       // Vector3 rotation = Quaternion.Lerp(turrentBase.rotation, lookRotate, Time.deltaTime * turrentSpeed).eulerAngles;
       //this actually turns the turrent
       // turrentBase.rotation = Quaternion.Euler(0f, rotation.y, 0f);
       turrentBase.LookAt(target);

       if (fireCountdown <= 0f) {
           Shoot();
           // if firerate is 2, fire 2 bullet each second, countdown from .5
           fireCountdown = (1f / fireRate);
       }

       fireCountdown -= Time.deltaTime;
    }

    void Shoot() {
    //shoots bullet
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint);
        GameObject Explosion_ = Instantiate(explosionFX, explodePos);
        Debug.Log("explosion");
        Destroy(Explosion_, 2f);
        Explosion_.transform.localScale = new Vector3(.2f, .2f, .2f);
        bulletGO.transform.localScale = new(.01f, .01f, .01f);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        
        //plays shooting sfx
        AudioSource.PlayClipAtPoint(soundFX, transform.position);
        
        if (bullet != null) bullet.Seek(target);
        // Debug.Log("Shoot!");
    }

     void OnDrawGizmosSelected()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(transform.position, range);
     }
}
