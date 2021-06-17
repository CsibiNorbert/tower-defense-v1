using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private enemy targetEnemy;

    [Header("General")]
    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float turnSpeed = 10f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public float slowPercent = 0.4f;
    public LineRenderer lineRenderer;
    public ParticleSystem laserEffectParticle;
    public Light impactLaserLight;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;


    // The point in which we want to spawn the bullet (Empty game Object)
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        // invoke method for twice a sec
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser && lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                laserEffectParticle.Stop();
                impactLaserLight.enabled = false;
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            UseLaserBullet();
        } else
        {
            // Time to shoot now
            if (fireCountdown <= 0f)
            {
                Shoot();
                // This means if we want to shoot 2 bullets, we divide the second by that number and we will shoot 2 bullets each second.
                fireCountdown = 1f / fireRate;
            }
            // Every second it will be reduced by 1
            fireCountdown -= Time.deltaTime;
        }
    }

    private void UseLaserBullet()
    {
        // We cancel frame rates from computers with time.deltatime. its per second not per frame.
        // This is getting when we are updating each nearest enemy in the UpdateTarget
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);

        // TODO: enemy is pushed away from the map when is slowed
        //targetEnemy.Slow(slowPercent);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;

            laserEffectParticle.Play();
            impactLaserLight.enabled = true;
        }

        // 0 is the index of the first element in the line renderer
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        // WHEN WE WANT TO GET THE DIRECTION FROM ONE POINT TO ANOTHER
        // A TO B, WE GO FROM POS OF B MINUS POS OF A
        // THIS IS A POSITION THAT POINT BACKWARDS FROM TURRET ( TOWARDS TURRET )
        Vector3 dir = firePoint.position - target.position;
        laserEffectParticle.transform.position = target.position + dir.normalized;

        // We point in this direction ( towards turret )
        laserEffectParticle.transform.rotation = Quaternion.LookRotation(dir);

    }

    private void LockOnTarget()
    {
        // Get Vector which will point into the direction of our enemy ( which is just an arrow )
        // When we want to find the direction of an object, we find the B minus our pos A
        Vector3 direction = target.position - transform.position;
        // Quaterion is used for rotation
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // X Y Z angles
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); // we want to rotate on the y axis. We could have used the lookRotation but in this case it will rotate on all axis
    }

    private void Shoot()
    {
        GameObject bulletGameObject =  (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bulletScript = bulletGameObject.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetEnemyLocationFromTurret(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void UpdateTarget()
    {
        // Find all enemy tagged as "enemy"
        // find the closest one
        // check the closest is withing range
        // and set that target to that object

        // get alle enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float tempShortestDistanceOfEnemy = Mathf.Infinity; // we didn`t find any enemy
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            // Distance between our position and enemy`s position
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < tempShortestDistanceOfEnemy)
            {
                // we found an enemy that is closer
                tempShortestDistanceOfEnemy = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && tempShortestDistanceOfEnemy <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<enemy>();
        }
        else
        {
            target = null;
        }
    }
}
