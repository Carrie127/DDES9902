using UnityEngine;

public class BrewButton : MonoBehaviour
{
    public CupDetector cupDetector;

    public void Brew()
    {
        if(cupDetector.hasCup)
        {
            Debug.Log("Brewing coffee...");
        }
        else
        {
            Debug.Log("No cup!");
        }
    }
}