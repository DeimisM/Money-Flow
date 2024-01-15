using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FollowPath player;

    // Example dice roll function
    public void RollDice()
    {
        int diceResult = Random.Range(1, 7);

        // Set the current waypoint based on the dice result, with looping behavior
        player.currentWaypoint = (player.currentWaypoint + diceResult) % player.waypoints.Length;

        // Allow movement
        player.moveAllowed = true;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
