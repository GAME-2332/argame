using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerSpawn;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("I am being pressed");
            Instantiate(towerSpawn, transform.position, quaternion.identity);
        }
    }
}

