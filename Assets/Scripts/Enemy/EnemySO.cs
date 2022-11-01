using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemySO", menuName = "ScriptableObjects/EnemySO", order = 1)]
public class EnemySO : ScriptableObject
{
    [SerializeField]
    public string enemyname;
    [SerializeField]
    public int coinsDropped;
    [SerializeField]
    public int damage;
    [SerializeField]
    public int maxHealth;
    [SerializeField]
    public int currentHealth;
    [SerializeField]
    public float speed;
    [SerializeField]
    public float attackspeed;

    
}
