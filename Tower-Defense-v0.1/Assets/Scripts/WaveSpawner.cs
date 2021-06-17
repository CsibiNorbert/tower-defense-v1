using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text WaveCountdownText;

    public float timeBetweenWaves = 5f;

    private int waveNumber = 0;
    private float countDown = 2f;

    // Update is called once per frame
    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        // It will reduce countDown every second by 1
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        WaveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    private IEnumerator SpawnWave()
    {
        waveNumber++;
        PlayerStats.roundsSurvived = waveNumber;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position, spawnPoint.rotation);
    }
}
