using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameManager gameManager;

    public Transform[] waypoints;

    float moveSpeed = 10f;

    public int currentWaypoint = 0;
    private int previousWaypoint = 0;

    public bool moveAllowed = false;

    private void Start()
    {
        transform.position = waypoints[currentWaypoint].transform.position;
    }

    private void Update()
    {
        if (moveAllowed)
        {
            Move();
        }
    }

    private void Move()
    {
        if (currentWaypoint <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[currentWaypoint].transform.position)
            {
                previousWaypoint = currentWaypoint;

                moveAllowed = false; // after the move is completed, stop further movement
                ActivateCardPicking();
            }
        }
    }

    private void ActivateCardPicking()
    {
        // Check if the waypoint has a Cards script attached
        Cards cardsComponent = waypoints[currentWaypoint].GetComponent<Cards>();

        if (cardsComponent != null)
        {
            // Pick a card from the selected group
            cardsComponent.PickCardFromGroup(cardsComponent.selectedCardGroup);

            // Check if the current waypoint is 6 or 12
            // Check if the player passed waypoint 6
            if (previousWaypoint < 6 && currentWaypoint >= 6)
            {
                gameManager.Payday();
                Debug.Log("Payday triggered while passing waypoint: " + currentWaypoint);
            }


            // Now, previousWaypoint contains the index of the previous waypoint
            Debug.Log("Previous Waypoint: " + previousWaypoint);
        }
        else
        {
            Debug.LogError("Cards component not found on waypoint object.");
        }
    }
}
