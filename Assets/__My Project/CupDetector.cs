using UnityEngine;

public class CupDetector : MonoBehaviour
{
    public bool hasCup = false;
    public Transform snapPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cup"))
        {
            hasCup = true;
            Debug.Log("Cup detected!");

            other.transform.position = snapPoint.position;
            other.transform.rotation = snapPoint.rotation;

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cup"))
        {
            hasCup = false;
            Debug.Log("Cup removed!");
        }
    }
}