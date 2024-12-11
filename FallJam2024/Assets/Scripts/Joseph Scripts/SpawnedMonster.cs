using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedMonster : MonoBehaviour
{
    public float health = 1f; // Initial health of the object

    public bool IsgoingDown;
    public float speed = 5f; // Speed of movement


    void Start()
    {
        CheckScreenHalf();
    }

    void Update()
    {
        if (IsgoingDown == false)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the trigger-entering object has the tag "spell"
        if (other.CompareTag("spell"))
        {
            OnSpellContact();
        }
    }

    void CheckScreenHalf()
    {
        // Get the main camera
        Camera mainCamera = Camera.main;

        // Convert the object's world position to screen position
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);

        // Get the screen's height
        float screenHeight = Screen.height;

        // Determine whether the object is in the top or bottom half
        if (screenPosition.y > screenHeight / 2)
        {
            Debug.Log(gameObject.name + " spawned in the top half of the screen.");
            IsgoingDown = true;
        }
        else
        {
            Debug.Log(gameObject.name + " spawned in the bottom half of the screen.");
            IsgoingDown = false;
        }
    }

    private void OnSpellContact()
    {
        health -= 1;

        // Check if health is zero or less
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log($"{gameObject.name} has been destroyed.");
        Destroy(gameObject); // Destroys the GameObject
    }

}
