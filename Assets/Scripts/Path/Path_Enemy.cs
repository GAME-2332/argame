using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Path_Enemy : MonoBehaviour
{
    //public EnemyClass enemyClassObj;

    public bool CanMove { get; private set; } = true;
    public float maxFollowDistance = 5;

    public Transform[] pathTarget;
    [SerializeField]
    private int CurrentPosition;

    public float Speed;

    public float Distance;
    bool bFound = false;

    float checkDistance;
    float angle;

    public int dealDamage = 10;

    public void SetTargetpath(Transform[] pathTargets)
    {
        pathTarget = pathTargets;
    }

    public void SetSpeed(float SpeedE)
    {
        Speed = SpeedE;

    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentPosition = 0;

        bFound = false;
        //var enemy = GetComponent<EnemyClass>();
        //pathTarget = enemy.GetPathTarget();
        //Speed = enemy.GetSpeed();

    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
        //findEnemyObject();
    }

    public void FollowPath()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxFollowDistance))
        {
            var other = hit.transform.GetComponent<Path_Enemy>();
            var player = hit.transform.GetComponent<Player>();
            if (other != null || player != null)
            {
                Debug.Log("Hit enemy");
                CanMove = false;

                if (player != null)
                { 
                    Debug.Log("Hit player");
                }

                CanMove = false;

                Distance = Vector3.Distance(player.transform.position, transform.position);
                if (Distance < 1.5)
                {
                     player.TakeDamage(dealDamage);
                }
            }

            else CanMove = true;
        } 
        else 
        {
            CanMove = true;
        }

        if (!CanMove || CurrentPosition >= pathTarget.Length) return;

        if (transform.position != pathTarget[CurrentPosition].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, pathTarget[CurrentPosition].position, Speed * Time.deltaTime);
            transform.LookAt(pathTarget[CurrentPosition].position);
        }

        else
        {
            CurrentPosition = (CurrentPosition + 1);
        }
    }

    public void findEnemyObject()
    {
        GameObject [] targetEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        Transform[] targetTransform = new Transform[targetEnemy.Length];
        int i;

        
        for (i = 0; i < targetTransform.Length; i++)
        {
            targetTransform[i] = targetEnemy[i].transform;
            Vector3 EnemyDirection = targetTransform[i].position - transform.position;

            checkDistance = Vector3.Distance(targetTransform[i].transform.position, transform.position);

            angle = Vector3.Angle(EnemyDirection, transform.forward);
            Debug.Log(targetEnemy[i]);
            
            if (targetEnemy[i])
            {
                bFound = true;
            }
        }

        if (bFound)
        {
            if (checkDistance < 0.5f && angle < 5.0f)
            {
                // stop movement
            }
            else
            {
                FollowPath();
            }
        }
        else
        {
            FollowPath();
        }
    }
}
