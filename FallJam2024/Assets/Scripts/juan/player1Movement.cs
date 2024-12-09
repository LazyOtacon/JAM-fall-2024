using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player1Movement : MonoBehaviour
{
    public GameObject spellProjectile; // The spell object to be instantiated

    public float movementSpeed = 20f; // Speed of player movement
    public float spellSpeed = 20f; // Speed of the spell

    private Vector2 keyboardInput; // Stores keyboard movement input

    void Update()
    {
        // Handle player movement based on keyboard input
        HandleMovement();

        // Handle spell casting when Space is pressed
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            CastSpell();
        }
    }

    // Handles player movement using keyboard input
    void HandleMovement()
    {
        // Get keyboard input
        float horizontal = 0f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1f;
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1f;
        }

        // Move the player horizontally
        Vector3 movement = new Vector3(horizontal * movementSpeed * Time.deltaTime, 0, 0);
        transform.Translate(movement);
    }

    // Instantiates and casts a spell
    void CastSpell()
    {
        Vector3 spellPosition = transform.position + new Vector3(0, 0.5f, 0); // Offset for the spell spawn position
        GameObject spell = Instantiate(spellProjectile, spellPosition, Quaternion.identity); // Create the spell
        spell.GetComponent<Rigidbody2D>().velocity = new Vector2(0, spellSpeed); // Apply velocity to the spell
    }
}
