using UnityEngine;
using System.Collections;

public class PickupCollectTrigger : MonoBehaviour
{
    [Header("References")]
    public GameObject collectPrompt3D;

    [Header("Spawn Settings")]
    public GameObject cupPrefab;
    public Transform spawnPoint;
    public float respawnDelay = 3f;

    [Header("Placement Settings")]
    public float requiredStillTime = 0.3f;
    public float velocityThreshold = 0.05f;

    private GameObject currentCupInZone;
    private Rigidbody currentCupRb;
    private float stillTimer = 0f;
    private bool cupIsPlaced = false;

    void Start()
    {
        if (collectPrompt3D != null)
        {
            collectPrompt3D.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cup"))
        {
            currentCupInZone = other.gameObject;
            currentCupRb = other.GetComponent<Rigidbody>();
            stillTimer = 0f;
            cupIsPlaced = false;

            if (collectPrompt3D != null)
            {
                collectPrompt3D.SetActive(false);
            }

            Debug.Log("Cup entered pickup zone");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("cup") && currentCupInZone == other.gameObject)
        {
            if (currentCupRb != null)
            {
                float speed = currentCupRb.linearVelocity.magnitude;
                float angularSpeed = currentCupRb.angularVelocity.magnitude;

                if (speed < velocityThreshold && angularSpeed < velocityThreshold)
                {
                    stillTimer += Time.deltaTime;

                    if (stillTimer >= requiredStillTime && !cupIsPlaced)
                    {
                        cupIsPlaced = true;

                        if (collectPrompt3D != null)
                        {
                            collectPrompt3D.SetActive(true);
                        }

                        Debug.Log("Cup placed and ready to collect");
                    }
                }
                else
                {
                    stillTimer = 0f;
                    cupIsPlaced = false;

                    if (collectPrompt3D != null)
                    {
                        collectPrompt3D.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cup") && currentCupInZone == other.gameObject)
        {
            currentCupInZone = null;
            currentCupRb = null;
            stillTimer = 0f;
            cupIsPlaced = false;

            if (collectPrompt3D != null)
            {
                collectPrompt3D.SetActive(false);
            }

            Debug.Log("Cup exited pickup zone");
        }
    }

    void Update()
    {
        if (cupIsPlaced && currentCupInZone != null && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F pressed, destroying cup");

            if (collectPrompt3D != null)
            {
                collectPrompt3D.SetActive(false);
            }

            Destroy(currentCupInZone);

            StartCoroutine(RespawnCup());

            currentCupInZone = null;
            currentCupRb = null;
            stillTimer = 0f;
            cupIsPlaced = false;
        }
    }

    IEnumerator RespawnCup()
    {
        Debug.Log("Respawn coroutine started");

        yield return new WaitForSeconds(respawnDelay);

        Debug.Log("Trying to respawn cup");

        if (cupPrefab != null && spawnPoint != null)
        {
            GameObject newCup = Instantiate(cupPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Cup respawned: " + newCup.name);
        }
        else
        {
            Debug.LogWarning("Cup prefab or spawn point is missing!");
        }
    }
}