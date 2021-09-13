using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSpeedMobile : MonoBehaviour
{
    [SerializeField]
    private GameObject thePlayer;

    [SerializeField]
    private float superSpeedBonus = 100f;

    // When Script enabled, add superSpeedBonus to sprintBonus from Movement Script
    private void OnEnable()
    {
        Debug.Log("Super Speed activated...");
        thePlayer.GetComponent<MobileMovement>().playerSpeed += superSpeedBonus;
    }

    // When Script enabled, subtract superSpeedBonus from sprintBonus from Movement Script
    private void OnDisable()
    {
        Debug.Log("Super Speed deactivated...");
        thePlayer.GetComponent<MobileMovement>().playerSpeed -= superSpeedBonus;
    }
}
