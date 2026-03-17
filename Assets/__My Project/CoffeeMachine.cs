using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    public GameObject cupPrefab;
    public Transform spawnPoint;

    void Start()
    {
        BrewCoffee();
    }

    public void BrewCoffee()
    {
        Instantiate(cupPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}