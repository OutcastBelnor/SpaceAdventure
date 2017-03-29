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
        if (other.CompareTag("Enemy") || other.CompareTag("GameSpace") || other.CompareTag("Heart"))
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            playerHealth.UpdateHealth(-10.0f);
        }
        else
        {
            Instantiate(asteroidExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }

        Destroy(this.gameObject);
    }
}