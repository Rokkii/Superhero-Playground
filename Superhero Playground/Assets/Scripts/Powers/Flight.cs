using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    [SerializeField]
    private float flightSpeed;

    private float activeFlightSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        activeFlightSpeed = Input.GetAxisRaw("Flight") * flightSpeed;
        transform.position += transform.up * activeFlightSpeed * Time.deltaTime;
    }
}
