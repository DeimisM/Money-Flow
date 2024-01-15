using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public FollowPath player;

    public TMP_Text salaryText;
    public TMP_Text jobTitleText;
    string job = "Police Officer Salary:";
    int salary = 2500;

    public TMP_Text taxesText;
    int taxes;

    int totalIncome;
    int totalExpenses;
    int payday;
    public TMP_Text totalIncomeText;
    public TMP_Text totalExpensesText;
    public TMP_Text paydayText;

    private void Start()
    {
        jobTitleText.text = job;
        salaryText.text = "$" + salary.ToString();

        taxes = salary / 100 * 35;
        taxesText.text = "$" + taxes.ToString();
    }

    private void Update()
    {
        totalExpenses = taxes;
        totalIncome = salary;
        payday = totalIncome - totalExpenses;

        totalIncomeText.text = "$" + totalIncome.ToString();
        totalExpensesText.text = "$" + totalExpenses.ToString();
        paydayText.text = "$" + payday.ToString();
    }

    public void RollDice()
    {
        int diceResult = Random.Range(1, 7);

        // Set the current waypoint based on the dice result with looping behavior
        player.currentWaypoint = (player.currentWaypoint + diceResult) % player.waypoints.Length;

        player.moveAllowed = true;
    }


}
