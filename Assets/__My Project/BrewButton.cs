using UnityEngine;
using System.Collections;

public class BrewButton : MonoBehaviour
{
    [Header("References")]
    public CupDetector cupDetector;
    public FloatingTextFade coffeeReadyEffect;
    public Renderer machineIndicator;
    public PickupArea pickupArea;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip brewingSound;
    public AudioClip readySound;

    [Header("Timing")]
    public float brewTime = 17f;

    private bool isBrewing = false;
    private Color originalColor;

    void Start()
    {
        if (machineIndicator != null)
        {
            originalColor = machineIndicator.material.color;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Brew();
        }
    }

    public void Brew()
    {
        if (isBrewing) return;

        if (cupDetector != null && cupDetector.hasCup)
        {
            StartCoroutine(BrewProcess());
        }
        else
        {
            Debug.Log("No cup detected.");
        }
    }

    IEnumerator BrewProcess()
    {
        isBrewing = true;

        Debug.Log("Brewing coffee...");

        // brewing sound
        if (audioSource != null && brewingSound != null)
        {
            audioSource.clip = brewingSound;
            audioSource.Play();
        }

        // machine indicator on
        if (machineIndicator != null)
        {
            machineIndicator.material.color = Color.yellow;
        }

        // wait brewing time
        yield return new WaitForSeconds(brewTime);

        // stop brewing sound
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        // ready sound
        if (audioSource != null && readySound != null)
        {
            audioSource.clip = readySound;
            audioSource.Play();
        }

        Debug.Log("Coffee ready!");

        // Coffee Ready text effect
        if (coffeeReadyEffect != null)
        {
            coffeeReadyEffect.Play();
        }

        // Pickup area glow
        if (pickupArea != null)
        {
            pickupArea.SetReady();
        }

        // machine indicator reset
        if (machineIndicator != null)
        {
            machineIndicator.material.color = originalColor;
        }

        isBrewing = false;
    }
}