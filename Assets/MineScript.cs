using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MineScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        playerHealth player = other.GetComponent<playerHealth>();
        if (player != null)
        {
            player.crash();   // disables the player
            Destroy(gameObject);
        }
    }
}