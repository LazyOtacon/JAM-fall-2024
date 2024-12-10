using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetector : MonoBehaviour
{
    public List<string> targetTags; // List of tags to detect

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object's tag is in the list
        if (targetTags.Contains(other.tag))
        {
            // Perform your action here
            Debug.Log(other.gameObject.name + " with tag " + other.tag + " entered the trigger!");
            //ADD GAME OVER HERE
        }
    }
}
