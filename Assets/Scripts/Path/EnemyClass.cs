using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    /*[System.Serializable]
    public struct DefineEnemyClass
    {*/
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
        [Tooltip("Spawn point")]
        public Transform spawnTransform;
        [Tooltip("Array of Enemy Path (Drop in EmptyObjects for path points)")]
        public Transform[] pathTarget;

        /*public DefineEnemyClass(float[] spawnTime, float waveLength, Vector3 spawnPosition, 
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
    DefineEnemyClass EnemyClass001;*/

    public float[] GetSpawnTime()
    {
        return spawnTime;
        //return EnemyClass001.spawnTime;
    }

    public float GetWaveTime()
    {
        return waveLength;
    }

    public Transform getSpawnTransform() {
        return spawnTransform;
    }

    public GameObject GetEnemy()
    {
        return enemyObject;
    }

    public float GetSpawnInterval()
    {
        return waveStart;
    }

    public float GetWaveInterval()
    {
        return spawnInterval;
    }

    public Transform[] GetPathTarget()
    {
        return pathTarget;
    }

    public float GetSpeed()
    {
        return enemySpeed;
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
