using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellDestroy2 : MonoBehaviour
{
    public float limitspell = -5.5f; // Maximum Y position before the bullet is destroyed.

    // Update is called once per frame
    void Update()
    {
        // Destroy the bullet if it goes above the defined Y position (limitspell).
        if (transform.position.y < limitspell)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check collision with specific tags and destroy the bullet if it hits one of these objects.
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy up"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy down"))
        {
            Destroy(gameObject);
        }
    }
}
