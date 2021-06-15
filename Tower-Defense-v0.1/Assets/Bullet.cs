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
    public float explosionRadius = 0f;

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

        // normilized means constant speed ( move missle toward enemy)
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        //Rotate bullet towards enemy pos
        transform.LookAt(target);

    }

    private void HitTarget()
    {
        Destroy(gameObject);

        if (explosionRadius > 0)
        {
            Explode();
        } else
        {
            Damage(target);
        }

        // Show effect once hit
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        // Destroy after 5 seconds
        Destroy(effectInstance, 5f);
    }

    private void Explode()
    {
        // Shoots a sphere and check all of the colliders that overlap with the sphere. Gets all of them
        Collider[] allEnemyInRange =  Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider enemyInRange in allEnemyInRange)
        {
            // Check if the object has enemy tag
            if (enemyInRange.tag == "Enemy")
            {
                Damage(enemyInRange.transform);
            }
        }
    }

    // This method is called in the turret to setup the enemy
    public void SetEnemyLocationFromTurret(Transform inputTarget)
    {
        // Set enemy
        target = inputTarget;
    }

    void Damage(Transform enemy)
    {
        // Destroy enemy
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
