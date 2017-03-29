using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private GameObject[] asteroidModels;

    [SerializeField]
    private float rotationSpeed;

    private Rigidbody mBody;
    
    private void Awake()
    {
        LoadModel();

        mBody = GetComponent<Rigidbody>();
        // Give the object a random angular velocity
        mBody.angularVelocity = Random.insideUnitSphere * rotationSpeed;
    }

    // Load model from available in the asteroidModels array.
    private void LoadModel()
    {
        GameObject asteroid = asteroidModels[Random.Range(0, asteroidModels.Length)];

        asteroid = Instantiate(asteroid, this.transform.position, this.transform.rotation) as GameObject;
        asteroid.transform.parent = this.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(5);
        }
    }
}
