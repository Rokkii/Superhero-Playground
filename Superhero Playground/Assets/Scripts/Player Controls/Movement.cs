using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;

    public float sprintBonus;

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
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Calculate input vector based on input values
        inputVector = (transform.right * x) +  (transform.forward * z);

        // Calculate movement velocity of player
        playerBody.velocity = inputVector * playerSpeed;

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
}
