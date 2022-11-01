using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewEnemyWave", menuName = "ScriptableObjects/EnemyWaveSO", order = 1)]

public class EnemyWaveSO : ScriptableObject
{
    [SerializeField]
    public int NumberOfEnemies;
    [SerializeField]
    public float Seconds_Between_Spawn;
    [SerializeField]
    public string EnemyPrefabPath;


}
