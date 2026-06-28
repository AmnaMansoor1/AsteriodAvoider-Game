using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public playerHealth player;
    public void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<playerHealth>();
        if (player != null)
        {
            player.crash();

        }
    }
}
