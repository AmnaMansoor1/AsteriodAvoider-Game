using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject minePrefab;
    public Camera cam;
    public float mineLifetime = 3f;   // how long each mine stays
    private GameObject currentMine;   // reference to the active mine

    void Start()
    {
        SpawnMine();
    }

    void SpawnMine()
    {
        // Random position inside camera view
        Vector2 randomViewport = new Vector2(Random.value, Random.value);
        Vector3 worldPosition = cam.ViewportToWorldPoint(randomViewport);
        worldPosition.z = 0f;

        // Destroy the old mine if it still exists (safety)
        if (currentMine != null)
            Destroy(currentMine);

        // Spawn new mine
        currentMine = Instantiate(minePrefab, worldPosition, Quaternion.identity);

        // Schedule its destruction after mineLifetime seconds
        Destroy(currentMine, mineLifetime);

        // Also schedule the next spawn after the same lifetime
        Invoke(nameof(SpawnMine), mineLifetime);
    }
}