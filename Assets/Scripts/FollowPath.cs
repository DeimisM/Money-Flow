using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameManager gameManager;
    public Transform[] waypoints;

    float moveSpeed = 10f;

    public int currentWaypoint = 0;

    public bool moveAllowed = false;
    bool donationCardSelected;
    bool dealSelected;

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
        donationCardSelected = false;
        dealSelected = false;

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

            if (currentWaypoint == 0)
            {
                donationCardSelected = true;
            }

            if (currentWaypoint == 2 || currentWaypoint == 5 || currentWaypoint == 7 || currentWaypoint == 10 || currentWaypoint == 13 || currentWaypoint == 15)
            {
                dealSelected = true;
            }
        }
        else
        {
            Debug.LogError("Cards component not found on waypoint object.");
        }
    }
    public void Donate()
    {
        if (donationCardSelected)
        {
            gameManager.Donation();
        }
    }

    public void BuyStocks()
    {
        if (dealSelected)
        {
            gameManager.BuyStocks();
        }
    }

    public void SellStocks()
    {
        if (dealSelected)
        {
            gameManager.SellStocks();
        }
    }
}
