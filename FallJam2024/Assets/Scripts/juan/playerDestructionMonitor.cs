using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDestructionMonitor : MonoBehaviour
{
    private gameOverMenu gameOverMenu;

    public AudioSource plrAS;
    public AudioClip plrDeathSfx;

    void Start()
    {
        // Find the Game Over Menu in the scene
        gameOverMenu = FindObjectOfType<gameOverMenu>();
    }

    void OnDestroy()
    {
        if (plrDeathSfx != null)
        {
            plrAS.PlayOneShot(plrDeathSfx);
        }
        if (gameOverMenu != null)
        {
            // Notify the Game Over Menu
            gameOverMenu.OnPlayerDestroyed(gameObject);
        }
    }
}
