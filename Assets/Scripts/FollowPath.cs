using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public Transform[] waypoints;

    float moveSpeed = 1f;

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
                currentWaypoint += 1;

                // Check if last waypoint
                if (currentWaypoint >= waypoints.Length)
                {
                    // If yes reset waypointto 0 to create a loop
                    currentWaypoint = 0;
                }
            }
        }
    }

}
