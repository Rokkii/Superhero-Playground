using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedRace : MonoBehaviour
{
    [SerializeField]
    private GameObject raceTimerText;

    [SerializeField]
    private GameObject raceCompleteUI;

    [SerializeField]
    private GameObject finalRaceTimeText;

    [SerializeField]
    private GameObject inGameTimerBoard;

    [SerializeField]
    private GameObject raceTriggerPrompt;

    [SerializeField]
    private float timePassed = 0f;

    [SerializeField]
    private GameObject[] raceTrackMarkers;

    [SerializeField]
    private GameObject nextRaceMarker;

    public int currentMarker = 0;

    // On beginning race, display race timer text UI and display timePassed to this text
    private void OnEnable()
    {
        Debug.Log("Race Begun!");
        raceTimerText.SetActive(true);
        raceTimerText.GetComponent<Text>().text = timePassed.ToString("0.0");
        Debug.Log("Number of race markers: " + raceTrackMarkers.Length);
        
        // Set first RaceMarker game object to enabled
        raceTrackMarkers[currentMarker].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Start timer counting up, update timer text per Update() loop
        timePassed += 1 * Time.deltaTime;
        raceTimerText.GetComponent<Text>().text = timePassed.ToString("0.0");
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if player collided with RaceMarker (checkpoint in race), and check if the current marker in order of the race
        if (collision.gameObject.name == nextRaceMarker.name & collision.transform.tag == "RaceMarker")
        {
            // If correct marker, disable current marker game object
            raceTrackMarkers[currentMarker].SetActive(false);
            Debug.Log("Player reached race marker " + currentMarker + " at time: " + timePassed);

            // Change current RaceMarker to next marker and enable game object
            currentMarker++;

            // If player has collided with all RaceMarkers, end race, reset currentMarker + timer to 0
            if (currentMarker >= raceTrackMarkers.Length)
            {
                Debug.Log("Race Complete! Time Taken: " + timePassed);

                // Update finalRaceTimeText to give player the time taken to complete race
                finalRaceTimeText.GetComponent<Text>().text = timePassed.ToString("0.0");

                // Update text of the in-game time board to display the completed race time
                inGameTimerBoard.GetComponent<Text>().text = timePassed.ToString("0.0");

                // Enable raceCompleteUI to display race time to player
                raceCompleteUI.SetActive(true);

                currentMarker = 0;
                timePassed = 0;

                // Reset nextRaceMarker to currentMarker, which will be 0
                nextRaceMarker = raceTrackMarkers[currentMarker];

                // Reset timer UI text to 0 and hide
                raceTimerText.SetActive(false);
                raceTimerText.GetComponent<Text>().text = timePassed.ToString("0.0");

                // Disable TimedRace script when race complete
                gameObject.GetComponent<TimedRace>().enabled = false;
                
                // Once reset all race components, exit race loop
                return;
            }

            raceTrackMarkers[currentMarker].SetActive(true);

            // Set next RaceMarker to the next RaceMarker in the array
            nextRaceMarker = raceTrackMarkers[currentMarker];
        }
        else if (collision.gameObject.name != nextRaceMarker.name & collision.transform.tag == "RaceMarker")
        {
            // Display error message if player hits wrong race marker
            Debug.Log("Player hit wrong race marker! At time: " + timePassed);
        }
    }

    // Trigger race start prompt if the player enters race area
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "RaceTriggerArea")
        {
            // Trigger prompt to start the race if player enters race area
            Debug.Log("Player entered race area!");
            raceTriggerPrompt.SetActive(true);
        }
    }

    // Disable race start prompt if the player leaves race area
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "RaceTriggerArea")
        {
            // Trigger prompt to start the race if player enters race area
            Debug.Log("Player left race area!");
            raceTriggerPrompt.SetActive(false);
        }
    }
}
