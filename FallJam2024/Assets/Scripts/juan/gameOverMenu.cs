using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class gameOverMenu : MonoBehaviour
{
    public Button restartButton; // Button to restart the game
    public Button exitButton; // Button to exit the game
    public GameObject gameOverMenuUI; // Reference to the Game Over menu UI
    private Vector2 playerInput; // Stores input for joystick navigation

    void Start()
    {
        // Assign listeners to the buttons
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
        Time.timeScale = 1f;
        // Ensure the Game Over menu is initially inactive
        gameOverMenuUI.SetActive(false);
        
    }

    void Update()
    {
        // Navigate buttons using joystick or keyboard
        HandleNavigation();
    }

    // Triggered when a GameObject with the "Player" tag is destroyed
    public void OnPlayerDestroyed(GameObject destroyedObject)
    {
        if (destroyedObject.CompareTag("player"))
        {
            ActivateGameOverMenu();
        }
    }

    // Activates the Game Over menu UI
    public void ActivateGameOverMenu()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    // Handles joystick or keyboard navigation
    public void OnMove(InputValue inputValue)
    {
        playerInput = inputValue.Get<Vector2>();
    }

    void HandleNavigation()
    {
        if (playerInput.y > 0.1f) // Move up
        {
            restartButton.Select();
        }
        else if (playerInput.y < -0.1f) // Move down
        {
            exitButton.Select();
        }
    }

    void RestartGame()
    {
        // Resume normal game speed
        Time.timeScale = 1f;

        // Destroy all active spells
        GameObject[] spells = GameObject.FindGameObjectsWithTag("spell");
        foreach (GameObject spell in spells)
        {
            Destroy(spell);
        }

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ExitGame()
    {
        // Resume normal game speed
        Time.timeScale = 1f;

        // Destroy all active spells
        GameObject[] spells = GameObject.FindGameObjectsWithTag("spell");
        foreach (GameObject spell in spells)
        {
            Destroy(spell);
        }

        // Exit the game or stop play mode in the editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
