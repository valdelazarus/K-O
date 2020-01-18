using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    private GameObject enemyPrefab;

    public int maxEnemiesNumber;

    int currentEnemyCount;

    void Awake() {

    }

    void Start() {
        SpawnEnemy();
    }

    public void SpawnEnemy() {
        currentEnemyCount++;
        if (currentEnemyCount > maxEnemiesNumber)
        {
            //load next level

            //below is temporary
            FindObjectOfType<LevelManager>().LoadScene("Game Win");
        }
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        
    }

} // class
