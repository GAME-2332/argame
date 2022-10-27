using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    EnemyWaveSO CurrentWave;
    [SerializeField]
    EnemySO CurrentEnemyType;

    [SerializeField]
    GameObject EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(EnemyPrefab == null)
        {
            EnemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Spawning an enemy.");
            CreateAnEnemy();
        }
    }

    void CreateAnEnemy()
    {
        GameObject go = Instantiate(EnemyPrefab);

        float random_x = Random.Range(0,10);
        float random_y = Random.Range(0,10);
        float random_z = Random.Range(0,10);


        go.transform.position = new Vector3(random_x, random_y, random_z);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        go.GetComponent<EnemyMovement>().SetDestination(player.transform);
    }
}
