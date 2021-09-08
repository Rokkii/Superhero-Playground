using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSpeed : MonoBehaviour
{
    [SerializeField]
    private GameObject thePlayer;

    [SerializeField]
    private float superSpeedBonus = 100f;

    // When Script enabled, add superSpeedBonus to sprintBonus from Movement Script
    private void OnEnable()
    {
        thePlayer.GetComponent<Movement>().sprintBonus += superSpeedBonus;
    }

    // When Script enabled, subtract superSpeedBonus from sprintBonus from Movement Script
    private void OnDisable()
    {
        thePlayer.GetComponent<Movement>().sprintBonus -= superSpeedBonus;
    }
}
