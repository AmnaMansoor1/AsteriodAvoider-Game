using UnityEngine;

public class TinniuqSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;   // assign TinniuqPlanet prefab
    public Camera cam;
    public float spawnInterval = 8f;   // every 8 seconds

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnPowerUp();
            timer = spawnInterval;
        }
    }

    void SpawnPowerUp()
    {
        Vector2 randomViewport = new Vector2(Random.value, Random.value);
        Vector3 worldPos = cam.ViewportToWorldPoint(randomViewport);
        worldPos.z = 0f;
        Instantiate(powerUpPrefab, worldPos, Quaternion.identity);
    }
}