using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    [System.Serializable]
    public struct DefineEnemyClass
    {
        [Tooltip("Enemy prefab in scene")]
        public GameObject enemyObject;
        [Tooltip("Enemy speed")]
        public float enemySpeed;
        [Tooltip("Array of Times for enemy waves (in seconds)")]
        public float[] spawnTime;
        [Tooltip("Lenght of wave (in seconds)")]
        public float waveLength; //wavetime
        [Tooltip("Start time of 1st Wave (In seconds)")]
        public float waveStart;
        [Tooltip("Interval between enemy spawn in a single Wave (in seconds)")]
        public float spawnInterval;
        [Tooltip("Position of spawn point (in Vector3)")]
        public Vector3 spawnPosition;
        [Tooltip("Array of Enemy Path (Drop in EmptyObjects for path points)")]
        public Transform[] pathTarget;

        public DefineEnemyClass(float[] spawnTime, float waveLength, Vector3 spawnPosition, 
                                GameObject enemyObject, float enemySpeed, Transform[] pathTarget, 
                                float waveStart, float spawnInterval)
        {
            this.spawnTime = spawnTime;
            this.waveLength = waveLength;
            this.spawnPosition = spawnPosition;
            this.enemyObject = enemyObject;
            this.pathTarget = pathTarget;
            this.enemySpeed = enemySpeed;
            this.waveStart = waveStart;
            this.spawnInterval = spawnInterval;
        }
    }

    [SerializeField]
    DefineEnemyClass EnemyClass001;

    public float[] GetSpawnTime()
    {
        return EnemyClass001.spawnTime;
    }

    public float GetWaveTime()
    {
        return EnemyClass001.waveLength;
    }

    public Vector3 GetSpawnPos()
    {
        return EnemyClass001.spawnPosition;
    }

    public GameObject GetEnemy()
    {
        return EnemyClass001.enemyObject;
    }

    public float GetSpawnInterval()
    {
        return EnemyClass001.waveStart;
    }

    public float GetWaveInterval()
    {
        return EnemyClass001.spawnInterval;
    }

    public Transform[] GetPathTarget()
    {
        return EnemyClass001.pathTarget;
    }

    public float GetSpeed()
    {
        return EnemyClass001.enemySpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}
