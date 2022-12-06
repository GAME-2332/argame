using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject[] getTotalSpawnTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTotalTime()
    {
        for (int i = 0; i < getTotalSpawnTime.Length - 1; i++)
        {
            //getTotalSpawnTime[i] = GetComponent<Enemy_Spwaner>();
        }
    }

}
