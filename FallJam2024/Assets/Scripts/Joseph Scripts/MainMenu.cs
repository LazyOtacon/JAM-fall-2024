using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton; // Button to start the game
    public Button exitButton; // Button to exit the game
    private Vector2 playerInput; // Stores input for joystick navigation

    void Start()
    {
        // Assign listeners to the buttons
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        // Navigate buttons using joystick or keyboard
        HandleNavigation();
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
            playButton.Select();
        }
        else if (playerInput.y < -0.1f) // Move down
        {
            exitButton.Select();
        }
    }

    // Method to start the game and load GameSceneNewPlayer
    void PlayGame()
    {
        SceneManager.LoadScene("GameSceneNewPlayer");
    }

    // Method to exit the game
    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
#else
            Application.Quit(); // Quit the application
#endif
    }
}
