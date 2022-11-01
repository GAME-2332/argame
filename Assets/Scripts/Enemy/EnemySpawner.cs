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
    List<EnemyWaveSO> AvailableWaves;

    [SerializeField]
    Transform SpawnPoint;//to be used by level designers.

    [SerializeField]
    GameObject EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(EnemyPrefab == null)
        {
            EnemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy/Enemy");
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if (CurrentWave != null) {
                Debug.Log("Spawning a wave.");
                CurrentWave = AvailableWaves[0];
                SpawnEnmiesByWave(CurrentWave);
            }

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (CurrentWave != null)
            {
                Debug.Log("Spawning another type of wave.");
                CurrentWave = AvailableWaves[1];
                SpawnEnmiesByWave(CurrentWave);
            }

        }
    }

    void SpawnEnmiesByWave(EnemyWaveSO _waveinfo)
    {
        StartCoroutine("SpawnAndWait", _waveinfo);
    }

    IEnumerator SpawnAndWait(EnemyWaveSO _waveinfo)
    {
        if (_waveinfo.EnemyPrefabPath != "")
        {
            EnemyPrefab = Resources.Load<GameObject>(_waveinfo.EnemyPrefabPath);
        }
        for (int i = 0; i < _waveinfo.NumberOfEnemies; i++)
        {
            CreateAnEnemy();
           
            yield return new WaitForSeconds(_waveinfo.Seconds_Between_Spawn);
        }
       
    }
    void CreateAnEnemy()
    {
        GameObject go = Instantiate(EnemyPrefab);

        float random_x = Random.Range(0,10);
        float random_y = Random.Range(0,10);
        float random_z = Random.Range(0,10);


        go.transform.position = new Vector3(random_x, random_y, random_z);
    }
}
