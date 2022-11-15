using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spwaner : MonoBehaviour
{
    [Tooltip("Enemy prefab in scene")]
    public EnemyClass enemyPrefab;

    public Path_Enemy enemyPath;

    private float[] SpawnTime;


    private float wavetime;

    private bool bTimer = false;
    private float timerCount;

    private GameObject enemyObject;

    private Vector3 spawnPosition;

    private float waveStart = 1.0f;

    private float spawnInterval = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //enemyPath = new Path_Enemy();
        //enemyPath = GetComponent<Path_Enemy>();

        bTimer = true;
        timerCount = 0;

        SpawnTime = enemyPrefab.GetSpawnTime();
        wavetime = enemyPrefab.GetWaveTime();
        enemyObject = enemyPrefab.GetEnemy();
        spawnPosition = enemyPrefab.GetSpawnPos();
        waveStart = enemyPrefab.GetSpawnInterval();
        spawnInterval = enemyPrefab.GetWaveInterval();

        enemyPath.SetSpeed(enemyPrefab.GetSpeed());
        enemyPath.SetTargetpath(enemyPrefab.GetPathTarget());

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
                Instantiate(enemyObject, spawnPosition, Quaternion.identity);
                
            }
        }
    }

    void SpawnRepeater()
    {
        InvokeRepeating("EnemySpawner", waveStart, spawnInterval);
    }
}
