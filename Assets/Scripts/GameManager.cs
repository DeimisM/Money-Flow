using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;

    public FollowPath player;

    public TMP_Text salaryText;
    public TMP_Text jobTitleText;
    string job = "Police Officer Salary:";
    int salary = 2500;

    int taxes;
    public TMP_Text taxesText;

    int totalIncome;
    int totalExpenses;
    int payday;
    public TMP_Text totalIncomeText;
    public TMP_Text totalExpensesText;
    public TMP_Text totalExpensesText1;
    public TMP_Text paydayText;

    int cash;
    public TMP_Text cashText;

    int mortgage;
    int mortgagePayment;
    public TMP_Text mortgageText;
    public TMP_Text mortgagePaymentText;

    int otherExpenses;
    public TMP_Text otherExpensesText;

    int loan;
    int loanPayment;
    public TMP_Text loanText;
    public TMP_Text loanPaymentText;

    int stocks;
    int stocksIncome;
    public TMP_Text stocksText;
    public TMP_Text stocksIncomeText;

    public Button rollButton;

    private bool isMoving = false;

    private void Start()
    {
        jobTitleText.text = job;
        salaryText.text = "$" + salary.ToString();

        taxes = salary / 100 * 30;
        taxesText.text = "$" + taxes.ToString();

        cash = 670;
        loan = 1000;
        stocks = 0;
        otherExpenses = salary / 100 * 17;

        mortgage = 40000;
        mortgagePayment = mortgage / 100;
        mortgageText.text = "$" + mortgage.ToString();
        mortgagePaymentText.text = "$" + mortgagePayment.ToString();

    }

    private void Update()
    {
        if (string.IsNullOrEmpty(uiManager.buttonText1.text.Trim()))
        {
            uiManager.buttonText1.enabled = false;
        }
        else
        {
            uiManager.buttonText1.enabled = true;
        }

        if (string.IsNullOrEmpty(uiManager.buttonText2.text.Trim()))
        {
            uiManager.buttonText2.enabled = false;
        }
        else
        {
            uiManager.buttonText2.enabled = true;
        }

        stocksIncome = stocks *= 5;

        totalExpenses = taxes + mortgagePayment + otherExpenses + loanPayment;
        totalIncome = salary + stocksIncome;
        payday = totalIncome - totalExpenses;

        totalIncomeText.text = "$" + totalIncome.ToString();
        totalExpensesText.text = "$" + totalExpenses.ToString();
        totalExpensesText1.text = "$" + totalExpenses.ToString();
        paydayText.text = "$" + payday.ToString();

        cashText.text = "$" + cash.ToString();

        loanPayment = loan / 100 * 10;
        loanText.text = "$" + loan.ToString();
        loanPaymentText.text = "$" + loanPayment.ToString();

        otherExpensesText.text = "$" + otherExpenses.ToString();

        stocksIncomeText.text = stocksIncome.ToString();
        stocksText.text = stocks.ToString();
    }

    public void RollDice()
    {
        if (!isMoving)
        {
            isMoving = true;

            int diceResult = Random.Range(1, 7);

            // set the current waypoint based on the dice result with looping behavior
            player.currentWaypoint = (player.currentWaypoint + diceResult) % player.waypoints.Length;

            StartCoroutine(MovePlayer());
        }
    }

    IEnumerator MovePlayer()
    {
        rollButton.gameObject.SetActive(false); // button invisible

        player.moveAllowed = true;

        // wait until the player has finished moving
        yield return new WaitUntil(() => !player.moveAllowed);

        // finished moving, make the button visible again
        rollButton.gameObject.SetActive(true);
        isMoving = false;
    }

    int timesLanded = 0;
    public void OnLandedOnBabyCard(Card babyCard)
    {
        timesLanded++;
        //Debug.Log("times landed");

        if (timesLanded <= 3)
        {
            otherExpenses += 80;
            otherExpensesText.text = "$" + otherExpenses.ToString();
            //Debug.Log("Updated otherExpenses: " + otherExpenses);
        }


        else
        {
            uiManager.headerText.text = "Limit Reached";
            uiManager.mainText.text = "You have reached the limit for having children.";
            uiManager.buttonText1.text = "";
            uiManager.buttonText2.text = "";
        }
    }

    public void OnLandedOnExpenseCard()
    {
        cash -= 50;
    }

    public void Downsized()
    {
        cash -= totalExpenses;
    }
}
