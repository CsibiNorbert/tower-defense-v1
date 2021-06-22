using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    // Current index point we are pursuing
    private int wavePointIndex = 0;

    private enemy Enemy;
    private Turret turret;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<enemy>();
        turret = GetComponent<Turret>();

        // First path
        target = waypoints.waypointList[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        // Normalized will have same speed
        transform.Translate(direction.normalized * Enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }

        // Maybe check this as I`m not sure if it is working. I`m checking when it stops shooting the laser to the enemy to reset the speed
        // However, maybe we need another check to make sure that the point of the laser, is pointing to the current enemy and not reseting all enemies
        //if (!turret.lineRenderer.enabled)
        //{
        //    // when finished hitting with laser, we return its original speed, its reseting our speed
        //    Enemy.speed = Enemy.startSpeed;
        //}
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
        WaveSpawner.enemiesAlive--;

        Destroy(gameObject);
    }
}
