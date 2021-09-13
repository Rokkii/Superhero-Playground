using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] respawnTriggers;

    [SerializeField]
    private GameObject[] respawnPoints;

    // If player collides with a respawn trigger, player will be teleported to associated respawn point (set in client)
    private void OnTriggerEnter(Collider other)
    {
        // If player hits a Respawn trigger tag, check array position
        if (other.transform.tag == "Respawn")
        {
            Debug.Log("Player died! Respawning...");

            for (int i = 0; i < respawnTriggers.Length; i++)
            {
                // Once found array position of the respawnTrigger, change position of the player to the respawnPoint with same array position (set in client)
                if (respawnTriggers[i].name == other.name)
                {
                    transform.position = respawnPoints[i].transform.position;
                    Debug.Log("Player respawned!");
                    break;
                }
            }
        }
    }
}
