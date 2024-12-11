using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield2 : MonoBehaviour
{
    public GameObject shieldDestroyParticles; // Optional particle effect for shield destruction
    public float shieldLifetime = 3.0f;       // Time in seconds before the shield destroys itself

    void Start()
    {
        // Schedule the shield to destroy itself after the specified lifetime
        Invoke(nameof(ExpireShield), shieldLifetime);
        Debug.Log($"Shield will destroy itself after {shieldLifetime} seconds.");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the tag "spell2"
        if (collision.CompareTag("spell"))
        {
            // Destroy the spell
            Destroy(collision.gameObject);

            // Optional: Instantiate destruction particles for the shield
            if (shieldDestroyParticles != null)
            {
                Instantiate(shieldDestroyParticles, transform.position, Quaternion.identity);
            }

            // Destroy the shield immediately upon collision
            Destroy(gameObject);
            Debug.Log("Shield destroyed by spell.");
        }
    }

    void ExpireShield()
    {
        // Spawn destruction particles when the shield expires
        if (shieldDestroyParticles != null)
        {
            Instantiate(shieldDestroyParticles, transform.position, Quaternion.identity);
        }

        // Destroy the shield game object
        Destroy(gameObject);
        Debug.Log("Shield expired and was destroyed.");
    }
}