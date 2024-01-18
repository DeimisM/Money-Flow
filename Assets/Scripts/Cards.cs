using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public string buttonText1;
    public string buttonText2;
    public string headerText;
    public string mainText;
    public CardGroup group; // Add a field to represent the card group
}

public enum CardGroup
{
    Deals,
    Expenses,
    Offers
}

public class Cards : MonoBehaviour
{
    public List<Card> allCards = new List<Card>();
    public CardGroup selectedCardGroup;

    void Start()
    {
        // Example: Adding cards programmatically with groups
        Card card1 = new Card
        {
            group = CardGroup.Deals,
            buttonText1 = "Attack",
            buttonText2 = "Defend",
            headerText = "header",
            mainText = "main"
        };
        //Card card2 = new Card { buttonText1 = "Heal", buttonText2 = "Use Item", group = CardGroup.Expenses };
        //Card card3 = new Card { buttonText1 = "Spell", buttonText2 = "Skip Turn", group = CardGroup.Offers };

        allCards.Add(card1);
        //allCards.Add(card2);
        //allCards.Add(card3);

        // Accessing cards in the list
        //Debug.Log("Card 1 Button 1 Text: " + allCards[0].buttonText1);
        //Debug.Log("Card 2 Button 2 Text: " + allCards[1].buttonText2);
        //Debug.Log("Card 3 Button 1 Text: " + allCards[2].buttonText1);

        // pick a card from a specific group
        //PickCardFromGroup(CardGroup.Deals);
        PickCardFromGroup(selectedCardGroup);
    }

    public void PickCardFromGroup(CardGroup group)
    {
        // Filter cards based on the specified group
        List<Card> groupCards = allCards.FindAll(card => card.group == group);

        // Pick a random card from the filtered list
        if (groupCards.Count > 0)
        {
            Card selectedCard = groupCards[Random.Range(0, groupCards.Count)];
            Debug.Log("Picked a card from group " + group + ": " + selectedCard.headerText);
        }
        else
        {
            Debug.LogWarning("No cards found in group " + group);
        }
    }
}
