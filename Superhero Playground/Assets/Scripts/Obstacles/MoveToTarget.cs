using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject[] movementTarget;

    [SerializeField]
    private GameObject respawnPoint;

    [SerializeField]
    private float movementSpeed = 10f;

    private int i = 0;

    // Update is called once per frame
    void Update()
    {
        // Obstacle object looks at specified target object (set in client), transforms obstacle position towards the target
        transform.LookAt(movementTarget[i].transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If obstacle collides with a game object with Obstacle tag, adds to the array so that the obstacle moves towards the next target in array
        if (collision.transform.tag == "Obstacle")
        {
            i++;

            // If i > greater than array length of obstacle movement targets, reset to 0, so obstacle moves to first target in the array
            if (i >= movementTarget.Length)
            {
                Debug.Log("Obstacle collided with all targets, resetting");
                i = 0;
            }
        }

        // If obstacle collides with player, respawn the player to specified game object position in client
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player hit obstacle! Respawning...");
            collision.transform.position = respawnPoint.transform.position;
        }
    }
}
