using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // bullet need a target. Pass on the target that its found under the turret to the bullet
    public Transform target;
    public float speed = 55f;
    public GameObject impactEffect;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // find the direction of our bullet to point in to look at the target
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //check if length of our direction, then we hit something
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        // normilized means constant speed
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        Destroy(gameObject);

        // Destroy enemy
        Destroy(target.gameObject);

        // Show effect once hit
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        // Destroy after 2 seconds
        Destroy(effectInstance, 2f);


    }

    // This method is called in the turret to setup the enemy
    public void SetEnemyLocationFromTurret(Transform inputTarget)
    {
        // Set enemy
        target = inputTarget;
    }
}
