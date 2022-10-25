using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spwaner : MonoBehaviour
{
    public GameObject enemy;

    public Vector3 spawn_pos;

    public float spawn_interval = 1.0f;
    public float wave_interval = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawner", spawn_interval, wave_interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemySpawner()
    {
        Instantiate(enemy, spawn_pos, Quaternion.identity);
    }
}
