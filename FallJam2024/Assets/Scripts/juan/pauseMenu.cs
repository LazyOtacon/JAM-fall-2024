using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Import the new Input System namespace

public class pauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // The main pause menu panel.
    public Button restartButton; // Button to restart the game.
    public Button exitButton; // Button to exit the game.
    public Button closeButton; // Button to close the pause menu.

    private bool isPaused = false; // Tracks whether the game is currently paused.

    void Start()
    {
        // Initialize the state of the menus.
        pausePanel.SetActive(false);

        // Assign actions to the buttons.
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitGame);
        closeButton.onClick.AddListener(TogglePause);
    }

    void Update()
    {
        // Toggle pause menu when the Escape key is pressed.
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause(); // Toggle the pause menu.
        }
    }

    // Toggles the pause state and shows/hides the pause menu.
    void TogglePause()
    {
        isPaused = !isPaused;

        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f; // Pause or resume game time.
    }

    // Restarts the current game scene and resets all game elements.
    void RestartGame()
    {
        Time.timeScale = 1f;

        // Destroy all spells currently in the game.
        GameObject[] spells = GameObject.FindGameObjectsWithTag("spell");
        foreach (GameObject spell in spells)
        {
            Destroy(spell);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene.
    }

    // Exits the game.
    void ExitGame()
    {
        Time.timeScale = 1f;

        // Destroy all spells currently in the game.
        GameObject[] spells = GameObject.FindGameObjectsWithTag("spell");
        foreach (GameObject spell in spells)
        {
            Destroy(spell);
        }

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor.
        #else
                Application.Quit(); // Quit the application.
        #endif
    }
}
