using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Enemy : MonoBehaviour
{
    public EnemyClass enemyClassObj;

    private Transform[] pathTarget;
    [SerializeField]
    private int CurrentPosition;

    private float Speed;

  

    // Start is called before the first frame update
    void Start()
    {
        CurrentPosition = 0;
        pathTarget = enemyClassObj.GetPathTarget();
        Speed = enemyClassObj.GetSpeed();
    }

    // Update is called once per frame
    void Update()
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
