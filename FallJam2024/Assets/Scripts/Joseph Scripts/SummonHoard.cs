using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonHoard : MonoBehaviour
{
    public List<Transform> enemies = new List<Transform>(); // Initialize list for dynamic management
    public float moveSpeed = 2f;
    public float boundaryMargin = 3.3f; // Adjustable margin to account for sprite size
    public float speedIncrease = 0.5f;  // Amount by which to increase speed
    public bool IsMovingDown;
    public float MoveDistance = 0.2f;

    private int direction = 1; // 1 for right, -1 for left
    private float boundaryLeft;
    private float boundaryRight;

    void Start()
    {
        UpdateBoundaries();
        UpdateEnemiesList();
    }

    void Update()
    {
        MoveEnemies();
        CheckBoundaries();
        CheckForDestroyedEnemies();
    }

    void UpdateBoundaries()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Vector3 leftEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 rightEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0));


            boundaryLeft = leftEdge.x + boundaryMargin;
            boundaryRight = rightEdge.x - boundaryMargin;
        }
    }

    void MoveEnemies()
    {
        foreach (Transform enemy in enemies)
        {
            if (enemy != null) // Ensure the enemy still exists
            {
                enemy.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);
            }
        }
    }

    void CheckBoundaries()
    {
        foreach (Transform enemy in enemies)
        {
            if (enemy != null)
            {
                if (enemy.position.x >= boundaryRight && direction == 1)
                {
                    ReverseDirection();
                    return;
                }
                else if (enemy.position.x <= boundaryLeft && direction == -1)
                {
                    ReverseDirection();
                    return;
                }
            }
        }
    }

    void ReverseDirection()
    {
        direction *= -1;
        foreach (Transform enemy in enemies)
        {
            if (enemy != null)
            {
                if (IsMovingDown)
                {
                    enemy.Translate(Vector3.down * MoveDistance); // Move down when reversing
                }
                else
                {
                    enemy.Translate(Vector3.down * (MoveDistance * -1)); // Move up when reversing
                }
            }
        }
    }

    void CheckForDestroyedEnemies()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null) // Enemy has been destroyed
            {
                enemies.RemoveAt(i); // Remove destroyed enemy
                moveSpeed += speedIncrease; // Increase move speed
            }
        }

        if (enemies.Count == 0)
        {
            Destroy(gameObject); //destroy useless object
        }
    }

    void UpdateEnemiesList()
    {

    }
}
