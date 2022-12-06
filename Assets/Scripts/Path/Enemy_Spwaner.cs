using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XR;

public class Enemy_Spwaner : MonoBehaviour
{
    public static bool IsAnySpawnerActive => _longestActiveSpawner != null;
    private static Enemy_Spwaner _longestActiveSpawner;

    [Tooltip("SpawnerDataPath in scene")]
    public EnemyClass SpawnerData;
    [Tooltip("Preafab from folder")]
    public Path_Enemy enemyPath;

    private float[] SpawnTime;


    private float wavetime;

    public bool bTimer = false;
    private float timerCount;

    private GameObject enemyObject;

    private Transform spawnTransform;

    private float waveStart = 1.0f;

    private float spawnInterval = 1.0f;

    private Path_Enemy _lastSpawned;
    
    // Start is called before the first frame update
    void Start()
    {
        //enemyPath = new Path_Enemy();
        //enemyPath = GetComponent<Path_Enemy>();

        bTimer = false;
        timerCount = 0;

        SpawnTime = SpawnerData.GetSpawnTime();
        wavetime = SpawnerData.GetWaveTime();
        enemyObject = SpawnerData.GetEnemy();
        spawnTransform = SpawnerData.getSpawnTransform();
        waveStart = SpawnerData.GetSpawnInterval();
        spawnInterval = SpawnerData.GetWaveInterval();

        // If this is longer than longestactivespawner or longestactivespawner is null, set longestactivespawner to this

#if UNITY_EDITOR
        SpawnRepeater();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (_lastSpawned != null && !_lastSpawned.CanMove) return;
        if (GameManager.GameState.IsPlaying())
        {
            bTimer = true;
            timerSTart();
        }
    }

    void timerSTart()
    {
        if (bTimer == true)
        {
            timerCount += Time.deltaTime;
            //Debug.Log("Time: " + timerCount);
        }
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
                _lastSpawned = enemy;

                // check if this is the last enemy to spawn; if it is, and longestactivespawner==this, then set longestactivespawner to null
            }
        }
    }

    public float SpawnTotalTime()
    {
        return SpawnerData.spawnTime[SpawnerData.spawnTime.Length - 1] + SpawnerData.waveLength;
    }

    public void SpawnRepeater()
    {
        InvokeRepeating("EnemySpawner", waveStart, spawnInterval);
    }
}
