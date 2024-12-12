using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoardMonsterHP : MonoBehaviour
{
    public float health = 1f; // Initial health of the object

    public bool IsP1hoard;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(IsP1hoard == true)
        {
            if (collision.gameObject.CompareTag("spell2"))
            {
                OnSpellContact();
                Destroy(collision.gameObject);
            }
        }
        if (IsP1hoard == false)
        {
            if (collision.gameObject.CompareTag("spell"))
            {
                OnSpellContact();
                Destroy(collision.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsP1hoard == true)
        {
            if (other.gameObject.CompareTag("spell2"))
            {
                OnSpellContact();
                Destroy(other.gameObject);
            }
        }
        if (IsP1hoard == false)
        {
            if (other.gameObject.CompareTag("spell"))
            {
                OnSpellContact();
                Destroy(other.gameObject);
            }
        }
    }

    /// <summary>
    /// Handles behavior when the object makes contact with a "spell."
    /// </summary>
    private void OnSpellContact()
    {
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

