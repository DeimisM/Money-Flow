using UnityEngine;
using UnityEngine.UI;

public class FinanceButton : MonoBehaviour
{
    public RectTransform uiElement;
    public float moveSpeed = 100f; // Adjust the speed as needed
    public float moveAmount = 100f; // Adjust the amount to move

    private bool moveRight = true; // Flag to determine the direction of movement

    void Start()
    {
        // Attach the button click event listener
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(MoveOnClick);
        }
    }

    public void MoveOnClick()
    {
        // Get the current position of the UI element
        Vector3 currentPosition = uiElement.anchoredPosition;

        // Update the X position based on the direction of movement
        if (moveRight)
        {
            currentPosition.x += moveAmount;
        }
        else
        {
            currentPosition.x -= moveAmount;
        }

        // Apply the updated position to the RectTransform
        uiElement.anchoredPosition = currentPosition;

        // Toggle the direction for the next click
        moveRight = !moveRight;
    }
}
