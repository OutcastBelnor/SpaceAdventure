using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private GameObject explosionPrefab;

    private Slider healthSlider;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider = FindObjectOfType<Slider>();

        healthSlider.maxValue = maxHealth;
    }

    private void Update()
    {
        healthSlider.value = currentHealth;
    }

    public void UpdateHealth(float value)
    {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0.0f, maxHealth);

        if (currentHealth == 0)
        {
            print("Player is Dead.");

            Instantiate(explosionPrefab, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }
}
