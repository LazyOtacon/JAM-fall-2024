using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDestructionMonitor : MonoBehaviour
{
    private gameOverMenu gameOverMenu;

    void Start()
    {
        // Find the Game Over Menu in the scene
        gameOverMenu = FindObjectOfType<gameOverMenu>();
    }

    void OnDestroy()
    {
        if (gameOverMenu != null)
        {
            // Notify the Game Over Menu
            gameOverMenu.OnPlayerDestroyed(gameObject);
        }
    }
}
