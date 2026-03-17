using UnityEngine;

public class CupDetector : MonoBehaviour
{
    public bool hasCup = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cup"))
        {
            hasCup = true;
            Debug.Log("Cup detected!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Cup"))
        {
            hasCup = false;
            Debug.Log("Cup removed!");
        }
    }
}