using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] enemyPrefab;

    public int numberOfWaves;
    public int minEnemiesPerWave;
    public int maxEnemiesPerWave;

    int currentWaveCount;
    int enemiesPerWave;

    void Awake() {

    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SpawnEnemyWave();
        }
    }

    public void SpawnEnemyWave()
    {
        currentWaveCount++;
        if (currentWaveCount > numberOfWaves)
        {
            Debug.Log("Level cleared!");
            FindObjectOfType<LevelManager>().LoadNextScene();
        }
        else
        {
            enemiesPerWave = Random.Range(minEnemiesPerWave, maxEnemiesPerWave + 1);
            for (int i = 0; i < enemiesPerWave; ++i)
            {
                int enemy = Random.Range(0, enemyPrefab.Length);
                Instantiate(enemyPrefab[enemy], transform.position + Vector3.left*i, Quaternion.identity);
            }
        }
        

    }

} 
