using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player2Movement : MonoBehaviour
{
    public GameObject spellProjectile; // The spell object to be instantiated
    public GameObject shieldPrefab; // The shield prefab to be instantiated

    public float movementSpeed = 20f; // Speed of player movement
    public float spellSpeed = 20f; // Speed of the spell

    public float minX = -5f; // Minimum X position for movement
    public float maxX = 5f;

    private Vector2 playerMove; // Stores input for movement (keyboard/joystick)
    private GameObject activeShield; // Reference to the active shield

    public float fireCooldown = 1.0f; // Cooldown time in seconds.

    private float lastFireTime = -Mathf.Infinity; // Tracks when the spell was last fired.

    public float ShieldCooldown = 12.0f; // Cooldown time in seconds.

    private float lastShieldTime = -Mathf.Infinity; // Tracks when the spell was last fired.

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
        if (inputValue.isPressed && Time.time >= lastFireTime + fireCooldown)
        {
            CastSpell();
            lastFireTime = Time.time; // Update the last fire time.
            Debug.Log("Fire Input Triggered");
        }
        else if (inputValue.isPressed)
        {
            Debug.Log("Fire is on cooldown.");
        }
    }

    // Input System for activating a shield
    public void OnShield(InputValue inputValue)
    {
        if (inputValue.isPressed && Time.time >= lastShieldTime + ShieldCooldown && activeShield == null)
        {
            ActivateShield();
            lastShieldTime = Time.time; // Update the last shield activation time.
            Debug.Log("Shield Input Triggered");
        }
        else if (inputValue.isPressed)
        {
            Debug.Log("Shield is on cooldown.");
        }
    }

    // Instantiates and casts a spell
    void CastSpell()
    {
        Vector3 spellPosition = transform.position + new Vector3(0, -0.5f, 0); // Offset for the spell spawn position
        GameObject spell = Instantiate(spellProjectile, spellPosition, Quaternion.Euler(0, 0, 180)); // Create the spell
        spell.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -spellSpeed); // Apply velocity to the spell
    }

    // Activates the shield
    void ActivateShield()
    {
        Vector3 shieldPosition = transform.position; // Shield spawns at the player's position
        activeShield = Instantiate(shieldPrefab, shieldPosition, Quaternion.identity);
        activeShield.transform.SetParent(transform); // Attach the shield to the player
    }
}
