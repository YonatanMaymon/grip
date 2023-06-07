using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemeySpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenWaves;
    public Wave[] waves;
    private float timer;
    [HideInInspector] public GameObject[] allEnemies;
    public TextMeshProUGUI UITimer;


    private void Start()
    {
        StartCoroutine(WaveSpawner(0));
    }


    private IEnumerator WaveSpawner(int i)
    {
        yield return StartCoroutine(SpawnWave(waves[i]));

        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject liveEnemy in allEnemies)
        {
            Destroy(liveEnemy);
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        if (i< waves.Length)
        {
            StartCoroutine(WaveSpawner(i + 1));
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        StartTimer();
        while (!TimerEnd(wave.waveLeangth))
        {
            foreach (Enemy enemy in wave.enemies)
            {
                GameObject newEnemy = Instantiate(enemy.enemy, new Vector3(Random.Range(-350f, 480f), Random.Range(-240f, 130f), 0), Quaternion.identity);
                yield return new WaitForSeconds(1 / enemy.spawnRate);
            }
        }
        yield return new WaitForSeconds(wave.complitionTime);
    }



    void StartTimer()
    {
        timer = Time.fixedTime;
    }
    private bool TimerEnd(float t)
    {
        UITimer.text = (t - Time.fixedTime - timer).ToString();
        if (t <= Time.fixedTime - timer)
        {
            return true;
        }
        return false;
    }
}
