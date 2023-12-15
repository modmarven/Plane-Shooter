using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float spawnTime = 2.0f;

    void Start()
    {
        StartCoroutine(enemySpawnerTime());
    }

    
    void Update()
    {
        
    }

    IEnumerator enemySpawnerTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int randomEnemy = Random.Range(0, enemy.Length);
        int randomXPos = Random.Range(-4, 4);
        Instantiate(enemy[randomEnemy], new Vector2(randomXPos, transform.position.y), Quaternion.identity);
    }
}
