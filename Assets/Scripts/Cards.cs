using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Card
{
    public string buttonText1;
    public string buttonText2;
    public string headerText;
    public string mainText;
    public CardGroup group; // Add a field to represent the card group

    public TextMeshProUGUI headerTextMesh;
    public TextMeshProUGUI mainTextMesh;
    public TextMeshProUGUI buttonText1Mesh;
    public TextMeshProUGUI buttonText2Mesh;
}

public enum CardGroup
{
    Deals,
    Expenses,
    Offers,
    Money,
    Donation,
    Baby,
    Downsize,
    Start
}

public class Cards : MonoBehaviour
{
    public UIManager uiManager;
    public GameManager gameManager;

    public List<Card> allCards = new List<Card>();
    public CardGroup selectedCardGroup;

    void Start()
    {
        // Example: Adding cards programmatically with groups

        Card startCard = new Card   // neaddinam i allcard list kad negaletu papickint veliau zaidime
        {
            group = CardGroup.Start,
            headerText = "Welcome to the Game!",
            mainText = "This is the start of your journey. Make wise choices to win! Press \"Roll\" to start.",
            buttonText1 = "",
            buttonText2 = ""
        };

        Card deal1 = new Card
        {
            group = CardGroup.Deals,
            headerText = "DEAL OPPORTUNITY",
            mainText = "Leading bank wants to sell you stocks that pay dividends. Buy stocks?\n Price: $25\nMoneyflow: $5",
            buttonText1 = "Yes",
            buttonText2 = "No"
        };

        Card expense1 = new Card
        {
            group = CardGroup.Expenses,
            headerText = "Spending habbits!",
            mainText = "You went out with your friends last night. $50 had been deducted from you.",
            buttonText1 = "",
            buttonText2 = ""
        };

        Card offer1 = new Card
        {
            group = CardGroup.Offers,
            headerText = "Stock buyer",
            mainText = "Friend wants to buy your stocks for $50 each!\nCash: + $50\nMoneyflow: - $5",
            buttonText1 = "Yes",
            buttonText2 = "No"
        };

        Card money1 = new Card
        {
            group = CardGroup.Money,
            headerText = "PAYDAY!",
            mainText = "This day is your PAYDAY! Collect your cash and go win the game!",
            buttonText1 = "OK",
            buttonText2 = ""
        };

        Card donation = new Card
        {
            group = CardGroup.Donation,
            headerText = "Charity is coming after you!",
            mainText = "Would you like to donate $100 to starving children for good luck?",
            buttonText1 = "Yes",
            buttonText2 = "No"
        };

        Card baby = new Card
        {
            group = CardGroup.Baby,
            headerText = "Congratulations!",
            mainText = "A new player spawned in your family! Other expenses increased by $80.",
            buttonText1 = "OK",
            buttonText2 = ""
        };

        Card downsize = new Card
        {
            group = CardGroup.Downsize,
            headerText = "DOWNSIZED!",
            mainText = "You just lost your main source of income! 1 month of expenses has been paid.",
            buttonText1 = "",
            buttonText2 = ""
        };

        allCards.Add(deal1);
        allCards.Add(expense1);
        allCards.Add(offer1);
        allCards.Add(money1);
        allCards.Add(donation);
        allCards.Add(baby);
        allCards.Add(downsize);

        allCards.Add(startCard);

        // pick a card from a specific group
        //PickCardFromGroup(CardGroup.Deals);
        PickCardFromGroup(selectedCardGroup);

        DisplayStartCard();
    }

    void DisplayStartCard()
    {
        // Find the start card in the list
        Card startCard = allCards.Find(card => card.group == CardGroup.Start);

        // If the start card is found, update UI with the start card's information
        if (startCard != null)
        {
            uiManager.headerText.text = startCard.headerText;
            uiManager.mainText.text = startCard.mainText;
            uiManager.buttonText1.text = startCard.buttonText1;
            uiManager.buttonText2.text = startCard.buttonText2;

            Debug.Log("Displayed start card: " + startCard.headerText);
        }
        else
        {
            Debug.LogWarning("Start card not found.");
        }
    }

    public void PickCardFromGroup(CardGroup group)
    {
        // Filter cards based on the specified group
        List<Card> groupCards = allCards.FindAll(card => card.group == group);

        // Check if there are any cards in the group
        if (groupCards.Count > 0)
        {
            // Pick a random card from the filtered list
            Card selectedCard = groupCards[Random.Range(0, groupCards.Count)];

            // Check if the selected card is not null
            if (selectedCard != null)
            {
                // Update TextMeshPro text properties through the UI manager
                uiManager.headerText.text = selectedCard.headerText;
                uiManager.mainText.text = selectedCard.mainText;
                uiManager.buttonText1.text = selectedCard.buttonText1;
                uiManager.buttonText2.text = selectedCard.buttonText2;

                Debug.Log("Picked a card from group " + group + ": " + selectedCard.headerText);

                if (group == CardGroup.Baby)
                {
                    // call the OnLandedOnBabyCard function in the GameManager
                    gameManager.OnLandedOnBabyCard(selectedCard);
                }

                if (group == CardGroup.Expenses)
                {
                    gameManager.OnLandedOnExpenseCard();
                }

                if (group == CardGroup.Downsize)
                {
                    gameManager.Downsized();
                }

                if (group == CardGroup.Money)
                {
                    gameManager.Payday();
                }
            }
            else
            {
                Debug.LogWarning("Selected card is null.");
            }
        }
        else
        {
            Debug.LogWarning("No cards found in group " + group);
        }
    }
}
