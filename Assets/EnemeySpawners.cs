using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeySpawners : MonoBehaviour
{


    // create 3 enemy prefabs
    [SerializeField] private GameObject[] enemies;
    // spawn rate
    [SerializeField] private float spawnRate = 0.5f;

    private float lastTimeSpawned = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      // spawn enemy
      if (Time.time - lastTimeSpawned > spawnRate) {
        SpawnEnemy();
        lastTimeSpawned = Time.time;
      }
    }

    Vector3 GetSpawnPositionOutsideViewBox() {
      // get random position
      float randomX = Random.Range(-10f, 10f);
      float randomY = Random.Range(-10f, 10f);

      Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

      // get camera bounds
      float camHeight = Camera.main.orthographicSize;
      float camWidth = camHeight * Camera.main.aspect;

      // check if random position is in camera
      while (randomPosition.x < camWidth && randomPosition.x > -camWidth && randomPosition.y < camHeight && randomPosition.y > -camHeight) {
        // get new random position
        randomX = Random.Range(-10f, 10f);
        randomY = Random.Range(-10f, 10f);

        randomPosition = new Vector3(randomX, randomY, 0f);
      }

      return randomPosition;

    }

    void SpawnEnemy() {
      // get random enemy
      int randomEnemy = Random.Range(0, enemies.Length);

      // random positin
      Vector3 randomPosition = GetSpawnPositionOutsideViewBox();  

      // spawn enemy
      Instantiate(enemies[randomEnemy], randomPosition, Quaternion.identity);
    }
}
