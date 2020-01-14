using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;

    [SerializeField]
    private GameObject enemyPrefab;

    public int maxEnemiesNumber;

    int currentEnemyCount;

    void Awake() {
        if (instance == null)
            instance = this;
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
