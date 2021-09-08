using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField]
    private GameObject thePlayer;

    // Print to console when player enables teleportation skill - presses a button
    private void OnEnable()
    {
        Debug.Log("Teleportation activated...");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Beginning teleportation...");

            // Perform raycast from player's current mouse position
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Calculate where raycast hits 
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                transform.position = hit.point;
            }

            Debug.Log("Teleport to: " + hit.point);

            // Create temporary vector to add to thePlayer Y position when teleporting - prevents falling through game floor
            Vector3 temp = new Vector3(0, 5f, 0);
            thePlayer.transform.position += temp;

            // After completing teleportation, disable script - means player can click on screen without teleporting again
            GetComponent<Teleportation>().enabled = false;
        }
    }
}
