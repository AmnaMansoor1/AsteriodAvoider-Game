using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform player;          // Drag your player here in Inspector
    public Camera cam;
    public float spawnInterval = 4f;
    public float missileSpeed = 15f;
    public float angleOffset = 0f;

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
            SpawnMissile();
            timer = spawnInterval;
        }
    }

    void SpawnMissile()
    {
        // Choose a random edge
        int side = Random.Range(0, 4);
        Vector2 spawnViewport = Vector2.zero;

        switch (side)
        {
            case 0: spawnViewport.x = -0.1f; spawnViewport.y = Random.value; break;
            case 1: spawnViewport.x = 1.1f; spawnViewport.y = Random.value; break;
            case 2: spawnViewport.x = Random.value; spawnViewport.y = -0.1f; break;
            case 3: spawnViewport.x = Random.value; spawnViewport.y = 1.1f; break;
        }

        Vector3 spawnWorld = cam.ViewportToWorldPoint(spawnViewport);
        spawnWorld.z = 0f;

        // Instantiate missile
        GameObject newMissile = Instantiate(missilePrefab, spawnWorld, Quaternion.identity);

        // Configure missile
        Missile missileScript = newMissile.GetComponent<Missile>();
        if (missileScript != null)
        {
            missileScript.speed = missileSpeed;
            missileScript.angleOffset = angleOffset;
        }
        else
        {
            Debug.LogError("Missile prefab is missing the Missile script!");
        }
    }
}