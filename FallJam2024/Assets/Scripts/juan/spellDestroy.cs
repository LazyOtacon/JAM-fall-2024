using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellDestroy : MonoBehaviour
{
    public float limitspell = 5.5f; // Maximum Y position before the spell is destroyed.

    public float destroyAfterSeconds = 1.5f;

    public AudioSource spellAS;
    public AudioClip shieldHitSfx;

    void Start()
    {
        var spellGameObject = GameObject.FindGameObjectsWithTag("SpellAS")[0];
        spellAS = GameObject.FindGameObjectsWithTag("SpellAS")[0]
            .GetComponent<AudioSource>();
        // Schedule the destruction of the object
        Destroy(gameObject, destroyAfterSeconds);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // Destroy the spell if it goes above the defined Y position (limitspell).
    //    if (transform.position.y > limitspell)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("player"))
        {
            // Destroy the player and the spell.
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // Optionally notify the gameOverMenu.
            gameOverMenu gameOver = FindObjectOfType<gameOverMenu>();
            if (gameOver != null)
            {
                gameOver.OnPlayerDestroyed(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("shield") || collision.gameObject.CompareTag("shield2"))
        {
            // Check the tag of THIS gameobject.
            if (gameObject.CompareTag("spell") && collision.gameObject.CompareTag("shield2"))
            {
                spellAS.PlayOneShot(shieldHitSfx);
                Destroy(collision.gameObject); // Destroy Shield2
                Destroy(gameObject); // Destroy the spell after processing
            }
            else if (gameObject.CompareTag("spell2") && collision.gameObject.CompareTag("shield"))
            {
                spellAS.PlayOneShot(shieldHitSfx);
                Destroy(collision.gameObject); // Destroy Shield1
                Destroy(gameObject); // Destroy the spell after processing
            }

        }

        if (collision.gameObject.CompareTag("Enemy up") || collision.gameObject.CompareTag("Enemy down"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}
