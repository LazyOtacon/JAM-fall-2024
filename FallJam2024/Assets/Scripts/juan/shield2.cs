using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield2 : MonoBehaviour
{
    public GameObject shieldDestroyParticles; // Optional particle effect for shield destruction

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the tag "spell"
        if (collision.CompareTag("spell"))
        {
            // Destroy the spell
            Destroy(collision.gameObject);

            // Optional: Instantiate destruction particles for the shield
            if (shieldDestroyParticles != null)
            {
                Instantiate(shieldDestroyParticles, transform.position, Quaternion.identity);
            }

            // Destroy the shield
            Destroy(gameObject);

            Debug.Log("Shield and Spell Destroyed");
        }
    }
}
