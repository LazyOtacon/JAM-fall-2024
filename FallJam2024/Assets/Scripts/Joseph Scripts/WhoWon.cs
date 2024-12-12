using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For working with legacy UI components


public class WhoWon : MonoBehaviour
{
    public GameObject redWizard; // The Red Wizard GameObject
    public GameObject blueWizard; // The Blue Wizard GameObject

    public Text redWinText; // Text to display if the Red Wizard wins
    public Text blueWinText; // Text to display if the Blue Wizard wins

    private void Update()
    {
        // Check if RedWizard is destroyed
        if (redWizard == null && blueWinText != null && !blueWinText.gameObject.activeSelf)
        {
            blueWinText.gameObject.SetActive(true);
        }

        // Check if BlueWizard is destroyed
        if (blueWizard == null && redWinText != null && !redWinText.gameObject.activeSelf)
        {
            redWinText.gameObject.SetActive(true);
        }
    }
}
