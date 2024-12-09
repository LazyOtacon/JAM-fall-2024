using UnityEngine;

public class EnemyGroupManager : MonoBehaviour
{
    public Transform[] enemies;  // Array of all enemies in the group
    public float moveSpeed = 2f;
    public float boundaryMargin = 0.5f; // Adjustable margin to account for sprite size

    private int direction = 1; // 1 for right, -1 for left
    private float boundaryLeft;
    private float boundaryRight;

    void Start()
    {
        UpdateBoundaries();
    }

    void Update()
    {
        MoveEnemies();
        CheckBoundaries();
    }

    void UpdateBoundaries()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            Vector3 leftEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 rightEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0));

            // Apply the margin to the boundaries
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
                //enemy.Translate(Vector3.down * 1f); // Move down when reversing
            }
        }
    }
}
