using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player1Movement : MonoBehaviour
{
    public GameObject spellProjectile; // The spell object to be instantiated
    public GameObject shieldPrefab; // The shield prefab to be instantiated

    public float movementSpeed = 20f; // Speed of player movement
    public float spellSpeed = 20f; // Speed of the spell

    public float minX = -5f; // Minimum X position for movement
    public float maxX = 5f;

    private Vector2 playerMove; // Stores input for movement (keyboard/joystick)
    private GameObject activeShield; // Reference to the active shield

    void Update()
    {
        // Handle player movement based on input
        HandleMovement();
    }

    // Handles player movement using the playerMove vector
    void HandleMovement()
    {
        // Apply horizontal movement from input
        Vector3 movement = new Vector3(playerMove.x * movementSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement);

        // Clamp position within bounds
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            transform.position.z);
    }

    // Input System for movement
    public void OnMove(InputValue inputValue)
    {
        playerMove = inputValue.Get<Vector2>();
        Debug.Log("Movement Input: " + playerMove);
    }

    // Input System for firing
    public void OnFire(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            CastSpell();
            Debug.Log("Fire Input Triggered");
        }
    }

    // Input System for activating a shield
    public void OnShield(InputValue inputValue)
    {
        if (inputValue.isPressed && activeShield == null)
        {
            ActivateShield();
            Debug.Log("Shield Activated");
        }
    }

    // Instantiates and casts a spell
    void CastSpell()
    {
        Vector3 spellPosition = transform.position + new Vector3(0, 0.5f, 0); // Offset for the spell spawn position
        GameObject spell = Instantiate(spellProjectile, spellPosition, Quaternion.identity); // Create the spell
        spell.GetComponent<Rigidbody2D>().velocity = new Vector2(0, spellSpeed); // Apply velocity to the spell
    }

    // Activates the shield
    void ActivateShield()
    {
        Vector3 shieldPosition = transform.position; // Shield spawns at the player's position
        activeShield = Instantiate(shieldPrefab, shieldPosition, Quaternion.identity);
        activeShield.transform.SetParent(transform); // Attach the shield to the player
    }
}
