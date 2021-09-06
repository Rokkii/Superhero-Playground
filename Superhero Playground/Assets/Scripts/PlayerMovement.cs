using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private float sprintBonus;

    // Turn off cursor in-game
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update Camera Position based on user input (WASD key presses and mouse movement)
    void Update()
    {
        // Use internal Unity InputManager to get vertical axis, multiply by player speed
        float translation = Input.GetAxis("Vertical") * playerSpeed;

        // Use internal Unity InputManager to get horizontal axis, multiply by player speed
        float straffe = Input.GetAxis("Horizontal") * playerSpeed;

        // Update movement per Update() loop
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        // Push translation/straffe onto Z and X axis in-game
        transform.Translate(straffe, 0, translation);

        // Player Sprint - if player presses LeftShift, increase player speed by adding sprint bonus, subtract when key released
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerSpeed += sprintBonus;

        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed -= sprintBonus;
        }

        // Test purposes only - turn cursor back on if player hits escape key
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
