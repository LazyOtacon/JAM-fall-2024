using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; // Add this for UI elements like Slider

public class player1Movement : MonoBehaviour
{
    public GameObject spellProjectile; // The spell object to be instantiated
    public GameObject shieldPrefab; // The shield prefab to be instantiated
    public GameObject monsterPrefab; // The monster prefab to be instantiated
    public GameObject hoardPrefab; // The monster prefab to be instantiated

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

    public float MonsterCooldown = 12.0f; // Cooldown time in seconds.

    private float lastMonsterTime = -Mathf.Infinity; // Tracks when the spell was last fired.


    // UI References
    public Image fireCooldownImage; // Reference to the fire cooldown UI image
    public Image shieldCooldownImage; // Reference to the shield cooldown UI image
    public Image MonsterCooldownImage; // Reference to the monster cooldown UI image

    void Update()
    {
        // Handle player movement based on input
        HandleMovement();

        // Update the cooldown bar
        UpdateCooldownBars();
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

    public void OnSpawnMonster(InputValue inputValue)
    {
        if (inputValue.isPressed && Time.time >= lastMonsterTime + MonsterCooldown)
        {
            SummonMonster();
            lastMonsterTime = Time.time; // Update the last fire time.
            Debug.Log("Monster Input Triggered");
        }
        else if (inputValue.isPressed)
        {
            Debug.Log("Monster is on cooldown.");
        }
    }

    public void OnSpawnHoard(InputValue inputValue)
    {
        if (inputValue.isPressed && Time.time >= lastMonsterTime + MonsterCooldown)
        {
            SummonHoard();
            lastMonsterTime = Time.time; // Update the last fire time.
            Debug.Log("Hoard Input Triggered");
        }
        else if (inputValue.isPressed)
        {
            Debug.Log("Hoard is on cooldown.");
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

    void SummonMonster()
    {
        Vector3 MonsterPosition = transform.position + new Vector3(0, 1f, 0); // Offset for the spell spawn position
        Instantiate(monsterPrefab, MonsterPosition, Quaternion.identity); // Create the spell
    }

    void SummonHoard()
    {
        Vector3 MonsterPosition = transform.position + new Vector3(0, 5f, 0); // Offset for the spell spawn position
        Instantiate(hoardPrefab, MonsterPosition, Quaternion.identity); // Create the spell
    }

    // Updates the fire cooldown UI bar (using Image fillAmount)
    void UpdateCooldownBars()
    {
        // Fire cooldown
        float fireCooldownProgress = 1 - Mathf.Clamp01((Time.time - lastFireTime) / fireCooldown);
        fireCooldownImage.fillAmount = fireCooldownProgress;

        // Shield cooldown
        float shieldCooldownProgress = 1 - Mathf.Clamp01((Time.time - lastShieldTime) / ShieldCooldown);
        shieldCooldownImage.fillAmount = shieldCooldownProgress;

        float MonsterCooldownProgress = 1 - Mathf.Clamp01((Time.time - lastMonsterTime) / MonsterCooldown);
        MonsterCooldownImage.fillAmount = MonsterCooldownProgress;
    }

}
