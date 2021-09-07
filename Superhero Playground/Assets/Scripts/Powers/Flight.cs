using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    [SerializeField]
    private float flightSpeed;

    private float activeFlightSpeed;
    private float flightAcceleration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
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
