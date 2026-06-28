using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 5f;
    public float angleOffset = 0f;

    private Transform playerTarget;
    private bool hasHit = false;

    void Start()
    {
        // Find player by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTarget = playerObj.transform;
        }
        else
        {
            Debug.LogError("Missile: No GameObject with tag 'Player' found!");
            Destroy(gameObject, 0.1f);
            return;
        }

        // Auto destroy after lifetime
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (playerTarget == null) return;

        // Calculate direction to player
        Vector3 direction = (playerTarget.position - transform.position).normalized;

        // Move missile
        transform.position += direction * speed * Time.deltaTime;

        // Rotate to face direction (only Z axis)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + angleOffset);
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        // Check if we hit the player
        playerHealth player = other.GetComponent<playerHealth>();
        if (player != null)
        {
            player.crash();
            hasHit = true;
            Destroy(gameObject);
        }
    }
}