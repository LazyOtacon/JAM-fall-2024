using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float health = 4f; // Initial health of the object

    public AudioSource barrierAS;
    public AudioClip barrierHitSfx;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the tag "spell"
        if (collision.gameObject.CompareTag("spell") || collision.gameObject.CompareTag("spell2"))
        {
            Destroy(collision.gameObject);
            OnSpellContact();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger-entering object has the tag "spell"
        if (other.CompareTag("spell") || other.gameObject.CompareTag("spell2"))
        {
            Destroy(other.gameObject);
            OnSpellContact();
        }
    }

    /// <summary>
    /// Handles behavior when the object makes contact with a "spell."
    /// </summary>
    private void OnSpellContact()
    {
        barrierAS.PlayOneShot(barrierHitSfx);

        health -= 1;

        // Check if health is zero or less
        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Handles object destruction or death behavior.
    /// </summary>
    private void Die()
    {
        Debug.Log($"{gameObject.name} has been destroyed.");
        Destroy(gameObject); // Destroys the GameObject
    }
}