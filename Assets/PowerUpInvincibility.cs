using UnityEngine;

public class PowerUpInvincibility : MonoBehaviour
{
    public float invincibleDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        playerHealth player = other.GetComponent<playerHealth>();
        if (player != null)
        {
            player.ActivateInvincibility(invincibleDuration);
            Destroy(gameObject);   // planet disappears after collection
        }
    }
}