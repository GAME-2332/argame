using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewTowerSO", menuName = "ScriptableObjects/TowerSO", order = 1)]

public class TowerSO : ScriptableObject
{
    public string TowerName;
    public string Description;
    public Sprite Tower2dImage;
    public int TowerHP;
    public int TowerAttackDamage;
    public float TowerAttackSpeed;
    public float TowerRange;
    public int TowerCost;
    public string TowerPrefabPath;

}
