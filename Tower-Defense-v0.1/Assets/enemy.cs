using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f;

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

    private void GetNextWaypoint()
    {
        if (wavePointIndex >= waypoints.waypointList.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = waypoints.waypointList[wavePointIndex];
    }
}
