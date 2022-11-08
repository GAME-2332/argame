using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spwaner : MonoBehaviour
{
    public EnemyClass enemyClassObj;


    private float[] SpawnTime;


    private float wavetime;

    private bool bTimer = false;
    private float timerCount;

    private GameObject enemy;

    private Vector3 spawn_pos;

    private float spawn_interval = 1.0f;

    private float wave_interval = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        bTimer = true;
        timerCount = 0;

        SpawnTime = enemyClassObj.GetSpawnTime();
        wavetime = enemyClassObj.GetWaveTime();
        enemy = enemyClassObj.GetEnemy();
        spawn_pos = enemyClassObj.GetSpawnPos();
        spawn_interval = enemyClassObj.GetSpawnInterval();
        wave_interval = enemyClassObj.GetWaveInterval();


        SpawnRepeater();
    }

    // Update is called once per frame
    void Update()
    {
        timerCount += Time.deltaTime;
        Debug.Log("Time: " + timerCount);
    }

    void EnemySpawner()
    {
        for (int i = 0; i <= SpawnTime.Length; i++)
        {
            if (timerCount > SpawnTime[i] && timerCount <= SpawnTime[i] + wavetime)
            {
                Instantiate(enemy, spawn_pos, Quaternion.identity);
            }
        }
    }

    void SpawnRepeater()
    {
        InvokeRepeating("EnemySpawner", spawn_interval, wave_interval);
    }
}
