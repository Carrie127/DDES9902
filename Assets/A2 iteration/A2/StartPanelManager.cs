using UnityEngine;

public class StartPanelManager : MonoBehaviour
{
    [Header("References")]
    public GameObject startCanvas;
    public GameObject inGameGuideGroup;
    public GameObject playerObject;
    public Camera startCamera;
    public MonoBehaviour kioskTypable;

    void Start()
    {
        // Show start UI
        if (startCanvas != null)
        {
            startCanvas.SetActive(true);
        }

        // Hide in-game guide at the beginning
        if (inGameGuideGroup != null)
        {
            inGameGuideGroup.SetActive(false);
        }

        // Disable player at the beginning
        if (playerObject != null)
        {
            playerObject.SetActive(false);
        }

        // Enable start camera
        if (startCamera != null)
        {
            startCamera.gameObject.SetActive(true);
        }

        // Disable kiosk typing during intro screen
        if (kioskTypable != null)
        {
            kioskTypable.enabled = false;
        }

        // Show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartExperience()
    {
        Debug.Log("START button clicked");

        // Hide start UI
        if (startCanvas != null)
        {
            startCanvas.SetActive(false);
        }

        // Show in-game guide
        if (inGameGuideGroup != null)
        {
            inGameGuideGroup.SetActive(true);
        }

        // Disable start camera
        if (startCamera != null)
        {
            startCamera.gameObject.SetActive(false);
        }

        // Enable player
        if (playerObject != null)
        {
            playerObject.SetActive(true);
        }

        // Re-enable kiosk typing after intro
        if (kioskTypable != null)
        {
            kioskTypable.enabled = true;
        }

        // Lock cursor for first-person control
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}