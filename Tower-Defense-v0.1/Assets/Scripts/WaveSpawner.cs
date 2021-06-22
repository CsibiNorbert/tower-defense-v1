using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    // This will be used to not spawn another wave until all enemies are dead
    public static int enemiesAlive = 0;
    public GameManager gameManager;

    public WaveBlueprint[] waves;
    public Transform spawnPoint;
    public Text WaveCountdownText;

    public float timeBetweenWaves = 5f;

    private int waveNumber = 0;
    // Keeps track the when we need to spawn the next wave
    private float countDown = 2f;

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive > 0)
        {
            // Inside here it returns if we didn`t kill all the enemy, hence won`t spawn another wave
            return;
        }

        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            // when we begging spawning the wave, it won`t go through the next logic
            return;
        }

        // It will reduce countDown every second by 1
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        WaveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    private IEnumerator SpawnWave()
    {
        PlayerStats.roundsSurvived = waveNumber;

        // Get wave we want to spawn
        WaveBlueprint wave = waves[waveNumber];

        enemiesAlive = wave.amountEnemiesToSpawn;

        for (int i = 0; i < wave.amountEnemiesToSpawn; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        waveNumber++;

        if (waveNumber == waves.Length)
        {
            gameManager.LevelWin();
            // Disable script so that we don`t keep spawning enemies
            // Disable script
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemyToSpawn)
    {
        Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
