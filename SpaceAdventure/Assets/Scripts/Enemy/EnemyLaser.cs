using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidExplosion;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameSpace"))
        {
            return;
        }

        playerHealth.UpdateHealth(-10.0f);
        Destroy(this.gameObject);
    }
}