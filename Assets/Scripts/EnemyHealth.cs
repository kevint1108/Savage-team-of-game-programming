using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;  // Enemy can take 3 hits
    private int currentHealth;

    private ReactiveTarget reactiveTarget;  // Reference to the ReactiveTarget script

    void Start()
    {
        currentHealth = maxHealth;  // Set full health
        reactiveTarget = GetComponent<ReactiveTarget>();  // Get the ReactiveTarget component
    }

    public void TakeDamage()
    {
        currentHealth--;  // Reduce health by 1

        if (currentHealth <= 0)
        {
            Die();  // Call the death function
        }
    }

    void Die()
    {
        if (reactiveTarget != null)
        {
            reactiveTarget.ReactToHit();  // Trigger the death animation and destruction
        }
    }
}

