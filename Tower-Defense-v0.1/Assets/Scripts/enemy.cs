using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    // We need it public so that we access it from the movement script
    [HideInInspector]
    public float speed;

    public float enemyStartHealth = 100.0f;
    private float health;

    public int addMoney = 30;
    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthbar;

    // Update is called once per frame
    void Update()
    {

    }

    private void Start()
    {
        speed = startSpeed;
        health = enemyStartHealth;
    }

    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        healthbar.fillAmount = health / enemyStartHealth;

        if (health <= 0)
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

    public void Slow(float slowPercent)
    {
        // We calculate the slow from start speed, otherwise each frame the speed will be slower and slower to to the new value assigned to it.
        speed = startSpeed * (1f - slowPercent);
    }
}
