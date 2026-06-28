using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public float secondsDifference = 1.5f;
    public Vector2 forceRange;
    public Camera cam;
    float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            spawnAsteroid();
            timer += secondsDifference;
            //-0.5 
            //1 sec wait before updating 
        }
    }
    public void spawnAsteroid()
    {
        int side = Random.Range(0, 4);
        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;
        switch (side)
        {
            //left
            case 0:
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;//btw 0 and 1
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                //right
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2:
                //bottom
                spawnPoint.y = 0;
                spawnPoint.x = Random.value;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 3:
                //top
                spawnPoint.y = 1;
                spawnPoint.x = Random.value;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }//end swtich
        Vector3 worldpoint = cam.ViewportToWorldPoint(spawnPoint);
        worldpoint.z = 0;
        GameObject selectionAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
        GameObject asteroidInstance = Instantiate(
            selectionAsteroid,
            worldpoint,
            Quaternion.Euler(0, 0, Random.Range(0, 360))
            );
        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();
        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
    }
}