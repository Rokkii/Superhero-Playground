using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileLook : MonoBehaviour
{
    Vector2 lookMouse;
    Vector2 smoothMove;

    [SerializeField]
    private float sensitivity;

    [SerializeField]
    private float smoothing;

    [SerializeField]
    private GameObject character;

    [SerializeField]
    private Joystick lookJoystick;

    // Update is called once per frame
    void Update()
    {
        // Find change in mouse - mouseDelta
        var mouseDelta = new Vector2(lookJoystick.Horizontal, lookJoystick.Vertical);

        // Multiply mouseDelta by sensitivity and smoothing values set in client
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        // Use Lerp to move camera smoothly on x + y axis
        smoothMove.x = Mathf.Lerp(smoothMove.x, mouseDelta.x, 1f / smoothing);
        smoothMove.y = Mathf.Lerp(smoothMove.y, mouseDelta.y, 1f / smoothing);

        // Add smooth movement calculated to direction mouse looking
        lookMouse += smoothMove;

        // Use inverted value of lookMouse to control camera on right axis (up/down)
        transform.localRotation = Quaternion.AngleAxis(-lookMouse.y, Vector3.right);

        // Use value of lookMouse to rotate the player character obj, moving the camera + player on the x-axis
        character.transform.localRotation = Quaternion.AngleAxis(lookMouse.x, character.transform.up);
    }
}
