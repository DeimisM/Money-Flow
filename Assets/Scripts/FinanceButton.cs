using UnityEngine;
using UnityEngine.UI;

public class FinanceButton : MonoBehaviour
{
    public RectTransform uiElement;
    public float moveSpeed = 100f;
    public float moveAmount = 100f;

    private bool moveRight = true; // determine the direction of movement

    void Start()
    {
        // event listener
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(MoveOnClick);
        }
    }

    public void MoveOnClick()
    {
        // current position of the UI element
        Vector3 currentPosition = uiElement.anchoredPosition;

        // updating X position based on the direction of movement
        if (moveRight)
        {
            currentPosition.x += moveAmount;
        }
        else
        {
            currentPosition.x -= moveAmount;
        }

        // apply the updated position to the RectTransform
        uiElement.anchoredPosition = currentPosition;

        // toggle the direction for the next click
        moveRight = !moveRight;
    }
}
