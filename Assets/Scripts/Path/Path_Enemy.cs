using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Enemy : MonoBehaviour
{
    public Transform[] PatrolTarget;
    public int CurrentPosition;

    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        CurrentPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != PatrolTarget[CurrentPosition].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, PatrolTarget[CurrentPosition].position, Speed * Time.deltaTime);
            transform.LookAt(PatrolTarget[CurrentPosition].position);
        }

        else
        {
            CurrentPosition = (CurrentPosition + 1);
        }
    }
}
