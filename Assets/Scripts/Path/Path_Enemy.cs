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

    public int dealDamage;

    public float damageInterval;
    private float timerCount = 0.0f;

    public Tracking tracking { get; private set; }

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
        damageInterval = 1;
        CurrentPosition = 0;
        dealDamage = 10;

        bFound = false;
        //var enemy = GetComponent<EnemyClass>();
        //pathTarget = enemy.GetPathTarget();
        //Speed = enemy.GetSpeed();

    }

    // Update is called once per frame
    void Update()
    {
        /*if (GameManager.GameState.IsPlaying())
        {
            bTimer = true;
            timerSTart();
        }*/

        FollowPath();
        //findEnemyObject();
    }

    public void FollowPath()
    {
        RaycastHit hit;
        float rayLength = transform.lossyScale.z * maxFollowDistance * 10f;
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            var other = hit.transform.GetComponent<Path_Enemy>();
            if (other != null) {
                CanMove = false;
                tracking = Tracking.Enemy;
            }
            else
            {
                var player = hit.transform.GetComponent<Player>();
               
                if (player != null) {
                    tracking = Tracking.Player;
                    CanMove = false;

                    Debug.Log("Hit player");

                    if (Time.time > timerCount)
                    {
                        damagePlayer();
                        timerCount = Time.time + damageInterval;
                    }
                    //player.TakeDamage(dealDamage);
                }
                else {
                    CanMove = true;
                    tracking = Tracking.None;
                }
            }
        }
        else
        {
            CanMove = true;
            tracking = Tracking.None;
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

    public void damagePlayer()
    {
        Player player = GameObject.Find("Tower").GetComponent<Player>();
        player.TakeDamage(dealDamage);
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

    public enum Tracking {
        None,
        Player,
        Enemy
    }
}
