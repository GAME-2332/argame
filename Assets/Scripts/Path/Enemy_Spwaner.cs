using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spwaner : MonoBehaviour
{
    [Tooltip("SpawnerDataPath in scene")]
    public EnemyClass SpawnerData;
    [Tooltip("Preafab from folder")]
    public Path_Enemy enemyPath;

    private float[] SpawnTime;


    private float wavetime;

    private bool bTimer = false;
    private float timerCount;

    private GameObject enemyObject;

    private Transform spawnTransform;

    private float waveStart = 1.0f;

    private float spawnInterval = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //enemyPath = new Path_Enemy();
        //enemyPath = GetComponent<Path_Enemy>();

        bTimer = true;
        timerCount = 0;

        SpawnTime = SpawnerData.GetSpawnTime();
        wavetime = SpawnerData.GetWaveTime();
        enemyObject = SpawnerData.GetEnemy();
        spawnTransform = SpawnerData.getSpawnTransform();
        waveStart = SpawnerData.GetSpawnInterval();
        spawnInterval = SpawnerData.GetWaveInterval();

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
        for (int i = 0; i < SpawnTime.Length; i++)
        {
            if (timerCount > SpawnTime[i] && timerCount <= SpawnTime[i] + wavetime)
            {
                Path_Enemy enemy = Instantiate(enemyObject, spawnTransform.position, Quaternion.identity).GetComponent<Path_Enemy>();

                enemy.SetSpeed(SpawnerData.GetSpeed());
                enemy.SetTargetpath(SpawnerData.GetPathTarget());
            }
        }
    }

    void SpawnRepeater()
    {
        InvokeRepeating("EnemySpawner", waveStart, spawnInterval);
    }
}
