using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed;

    [SerializeField]
    private float sideSpeed;

    [SerializeField]
    private float sprintBonus;

    private float activeForwardSpeed;
    private float activeSideSpeed;

    // Turn off cursor in-game
    /*private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }*/

    // Update is called once per frame
    void Update()
    {
        // Get input speed for each axis
        activeForwardSpeed = Input.GetAxisRaw("Vertical") * forwardSpeed;
        activeSideSpeed = Input.GetAxisRaw("Horizontal") * sideSpeed;

        // Transform position based on input speed for each axis
        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position += transform.right * activeSideSpeed * Time.deltaTime;

        // Player Sprint - if player presses LeftShift, increase player speed by adding sprint bonus, subtract when key released
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            forwardSpeed += sprintBonus;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            forwardSpeed -= sprintBonus;
        }

        // Test purposes only - turn cursor back on if player hits escape key
        /*if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }*/
    }
}
