using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    // Time (in seconds) after which the object will be destroyed
    public float destroyAfterSeconds = 3f;

    void Start()
    {
        // Schedule the destruction of the object
        Destroy(gameObject, destroyAfterSeconds);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check collision with specific tags and destroy the bullet if it hits one of these objects.
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy up") || collision.gameObject.CompareTag("Enemy down"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
    }
}
