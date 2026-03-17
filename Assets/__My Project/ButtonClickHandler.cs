using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public BrewButton brewButton;

    private void OnMouseDown()
    {
        Debug.Log("Button clicked!");

        if (brewButton != null)
        {
            brewButton.Brew();
        }
        else
        {
            Debug.Log("brewButton reference is missing!");
        }
    }
}