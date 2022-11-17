using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Enemy : MonoBehaviour
{
    public EnemyClass enemyClassObj;

    public Transform[] pathTarget;
    [SerializeField]
    private int CurrentPosition;

    public float Speed;

  
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

        
        //var enemy = GetComponent<EnemyClass>();
        //pathTarget = enemy.GetPathTarget();
        //Speed = enemy.GetSpeed();

    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    public void FollowPath()
    {
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


}
