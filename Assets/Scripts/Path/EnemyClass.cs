using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    [System.Serializable]
    public struct DefineEnemyClass
    {
        [Tooltip("Array of Times for enemy waves (in seconds)")]
        public float[] spawnTime;
        [Tooltip("Lenght of wave (in seconds)")]
        public float wavetime; //wavetime
        [Tooltip("Position of spawn point (in Vector3)")]
        public Vector3 spawn_pos;
        [Tooltip("Enemy prefab in scene")]
        public GameObject enemy;
        [Tooltip("Enemy speed")]
        public float speed;
        [Tooltip("Array of Enemy Path (Drop in EmptyObjects for path)")]
        public Transform[] pathTarget;
        [Tooltip("Set it to 1")]
        public float spawn_interval;
        [Tooltip("Set it to 1")]
        public float wave_interval;

        public DefineEnemyClass(float[] spawnTime, float wavetime, Vector3 spawn_pos, 
                                GameObject enemy, float speed, Transform[] pathTarget, 
                                float spawn_interval, float wave_interval)
        {
            this.spawnTime = spawnTime;
            this.wavetime = wavetime;
            this.spawn_pos = spawn_pos;
            this.enemy = enemy;
            this.pathTarget = pathTarget;
            this.speed = speed;
            this.spawn_interval = spawn_interval;
            this.wave_interval = wave_interval;
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
        return EnemyClass001.wavetime;
    }

    public Vector3 GetSpawnPos()
    {
        return EnemyClass001.spawn_pos;
    }

    public GameObject GetEnemy()
    {
        return EnemyClass001.enemy;
    }

    public float GetSpawnInterval()
    {
        return EnemyClass001.spawn_interval;
    }

    public float GetWaveInterval()
    {
        return EnemyClass001.wave_interval;
    }

    public Transform[] GetPathTarget()
    {
        return EnemyClass001.pathTarget;
    }

    public float GetSpeed()
    {
        return EnemyClass001.speed;
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
