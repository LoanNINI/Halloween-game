using UnityEngine;

public class FriendPumkin : MonoBehaviour
{
    public GameObject player;          // Reference to the player GameObject
    public float followDistance = 3f;  // Desired distance the pumpkin should stay from the player
    public float maxDistance = 7f;     // Maximum distance before the pumpkin moves towards the player
    public float moveSpeed = 5f;       // Speed at which the pumpkin will move towards the player
    private SpriteRenderer spriteRenderer; // Reference to the sprite renderer for flipping

    void Start()
    {
        // Find and assign the player GameObject by its tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Get the SpriteRenderer component for flipping
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleMovement();
        FlipBasedOnPlayerPosition();
    }

    void HandleMovement()
    {
        if (player == null) return;

        // Calculate the distance between the player and the Friend Pumpkin
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // If the pumpkin is farther than 7 units, move it towards the player
        if (distanceToPlayer > maxDistance)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
        // Keep the pumpkin at a 3-unit distance
        else if (distanceToPlayer > followDistance)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            transform.position = player.transform.position - directionToPlayer * followDistance;
        }
    }

    void FlipBasedOnPlayerPosition()
    {
        // If the player is to the right of the pumpkin, set flipX to false
        if (player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        // If the player is to the left of the pumpkin, set flipX to true
        else if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }
}
