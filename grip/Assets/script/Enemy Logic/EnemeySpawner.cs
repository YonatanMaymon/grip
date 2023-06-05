using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeySpawner : MonoBehaviour
{
    [SerializeField] GameObject tree;
    [SerializeField] float enemySpwanRate;


    private void Start()
    {
        StartCoroutine(SpawnEnemy(enemySpwanRate, tree));
    }

    private IEnumerator SpawnEnemy(float spawnRate, GameObject enemy)
    {
        yield return new WaitForSeconds(1 / spawnRate);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-350f, 480f), Random.Range(-240f, 130f),0), Quaternion.identity);
        StartCoroutine(SpawnEnemy(spawnRate, enemy));
    }
}
