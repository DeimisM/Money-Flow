using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public Transform[] waypoints;

    float moveSpeed = 10f;

    public int currentWaypoint = 0;

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
                moveAllowed = false; // After the move is completed, stop further movement
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
        }
        else
        {
            Debug.LogError("Cards component not found on waypoint object.");
        }
    }
}
