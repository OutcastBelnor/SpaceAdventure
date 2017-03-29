using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private float fireSpeed;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private Transform shotSpawn;

    private void Update()
    {
        // If Fire1 is pressed start firing
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InvokeRepeating("Fire", 0.000001f, fireRate);
        }
        // If Fire1 is released stop firing
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            CancelInvoke("Fire");
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
