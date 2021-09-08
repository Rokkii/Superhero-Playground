using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    [SerializeField]
    private float flightSpeed = 10f;

    private float activeFlightSpeed;
    private float flightAcceleration = 2f;

    private void OnEnable()
    {
        Debug.Log("Flight activated...");
    }

    private void OnDisable()
    {
        Debug.Log("Flight deactivated...");
    }

    // Update is called once per frame
    void Update()
    {
        // Set Gravity component of RigidBody to false to allow flight
        gameObject.GetComponent<Rigidbody>().useGravity = false;

        // Get flight speed value
        activeFlightSpeed = Mathf.Lerp(activeFlightSpeed, Input.GetAxisRaw("Flight") * flightSpeed, flightAcceleration * Time.deltaTime);

        // Move player on flight axis (up/down) based on speed
        transform.position += transform.up * activeFlightSpeed * Time.deltaTime;
    }
}
