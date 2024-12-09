using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour
{
    public void OnPlayButtonStart ()
    {
        // loads the main scene for the game
        SceneManager.LoadScene("SampleScene");
    }

    public void OnQuitButtonStart ()
    {
        // shuts the application down
        Application.Quit();
    }
}
