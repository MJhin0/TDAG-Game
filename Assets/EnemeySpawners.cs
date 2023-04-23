using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeySpawners : MonoBehaviour
{


    // create 3 enemy prefabs
    [SerializeField] private GameObject[] enemies;

    // spawn rate
    [SerializeField] private float spawnRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      // spawn rate
      if (Time.time % spawnRate < 0.01f) {
        // spawn enemy
        SpawnEnemy();
      }  
    }

    void SpawnEnemy() {
      // get random enemy
      int randomEnemy = Random.Range(0, enemies.Length);
      // get random position
      Vector2 randomPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
      // spawn enemy
      Instantiate(enemies[randomEnemy], randomPosition, Quaternion.identity);
    }
}
