using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    public float playerSpeed = 10f;

    public float sprintBonus = 20f;

    [SerializeField]
    private Joystick moveJoystick;

    private Rigidbody playerBody;
    private Vector3 inputVector;

    // Turn off cursor in-game
    private void Start()
    {
        // Get RigidBody component attached to player obj
        playerBody = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Get input values for both axis
        float x = moveJoystick.Horizontal;
        float z = moveJoystick.Vertical;

        // Calculate input vector based on input values
        inputVector = transform.right * x +  transform.forward * z ;

        // Calculate movement velocity of player
        playerBody.velocity = inputVector * playerSpeed + Vector3.up * playerBody.velocity.y;

        // Player Sprint - if player presses LeftShift, increase player speed by adding sprint bonus, subtract when key released
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed += sprintBonus;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed -= sprintBonus;
        }

        // Test purposes only - turn cursor back on if player hits escape key
        /*if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }*/
    }

    // Add a method to toggle sprint on and off (for mobile only)
    public void PlayerSprintOn()
    {
        playerSpeed += sprintBonus;
    }

    public void PlayerSprintOff()
    {
        playerSpeed -= sprintBonus;
    }
}

