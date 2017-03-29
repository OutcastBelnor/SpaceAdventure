using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    private float fireSpeed;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private Transform shotSpawn;
    
    private float timeBetweenShots;

    private void Start()
    {
        timeBetweenShots = Time.time;
    }

    private void Update()
    {
        // Fires a laser every interval of time specified in fireRate
        if (Time.time - timeBetweenShots >= fireRate)
        {
            Fire();
            timeBetweenShots = Time.time;
        }
    }
    
    // Instantiates a laser bolt
    private void Fire()
    {
        Rigidbody laserBody = Instantiate(laserPrefab, shotSpawn.transform.position, shotSpawn.transform.rotation).
            GetComponent<Rigidbody>();

        laserBody.velocity = transform.forward * fireSpeed;
    }
}
