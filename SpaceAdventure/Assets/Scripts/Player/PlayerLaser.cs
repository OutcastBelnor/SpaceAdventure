using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidExplosion;
    [SerializeField]
    private GameObject enemyExplosion;

    private Score score;

    private void Start()
    {
        score = GameObject.FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("GameSpace") || other.CompareTag("Heart"))
        {
            return;
        }
        
        if(other.CompareTag("Asteroid"))
        {
            Instantiate(asteroidExplosion, other.transform.position, other.transform.rotation);

            score.UpdateScore(2);
        }
        else if (other.CompareTag("Enemy"))
        {
            Instantiate(enemyExplosion, other.transform.position, other.transform.rotation);

            score.UpdateScore(5);
        }

        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
