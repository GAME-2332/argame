using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{

    private Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform turrentBase;
    public float turrentSpeed = 10f;
    void Start() {
        //Repeats called method
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

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
        if (target == null)
            return;
        
           //Target Lock on
           Vector3 direction = target.position - transform.position;
           Quaternion lookRotate = Quaternion.LookRotation(direction);
           //When turrent looks at new enemy, it smoothly turns to the new enemy, instead of snapping 
           Vector3 rotation = Quaternion.Lerp(turrentBase.rotation, lookRotate, Time.deltaTime * turrentSpeed).eulerAngles;
           //this actually turns the turrent
           turrentBase.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

     void OnDrawGizmosSelected()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(transform.position, range);
     }
}
