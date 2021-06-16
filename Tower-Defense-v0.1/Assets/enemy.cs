using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f;
    public int enemyHealth = 100;
    public int addMoney = 30;
    public GameObject deathEffect;

    private Transform target;
    // Current index point we are pursuing
    private int wavePointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // First path
        target = waypoints.waypointList[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        // Normalized will have same speed
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
    }

    public void TakeDamage(int damageTaken)
    {
        enemyHealth -= damageTaken;

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AddMoneyToPlayer();

        GameObject dEffect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(dEffect, 5f);

        Destroy(gameObject);
    }

    private void AddMoneyToPlayer()
    {
        PlayerStats.money += addMoney;
    }

    private void GetNextWaypoint()
    {
        if (wavePointIndex >= waypoints.waypointList.Length - 1)
        {
            EndPath();
            return;
        }
        wavePointIndex++;
        target = waypoints.waypointList[wavePointIndex];
    }

    private void EndPath()
    {
        PlayerStats.playerLives--;
        Destroy(gameObject);
    }
}
