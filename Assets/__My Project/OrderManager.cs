using UnityEngine;
using TMPro;
using System.Collections;

public class OrderManager : MonoBehaviour
{
    [Header("Order Screen Text")]
    public TMP_Text orderText;

    [Header("Order Timing")]
    public float orderChangeInterval = 8f;

    private string[] orders =
    {
        "Order #101\n1 Latte\nDine-in",
        "Order #102\n1 Cappuccino\nDine-in",
        "Order #103\n1 Flat White\nDine-in",
        "Order #104\n1 Espresso\nTakeaway",
        "Order #105\n1 Long Black\nDine-in"
    };

    void Start()
    {
        StartCoroutine(ChangeOrdersOverTime());
    }

    IEnumerator ChangeOrdersOverTime()
    {
        while (true)
        {
            ShowRandomOrder();
            yield return new WaitForSeconds(orderChangeInterval);
        }
    }

    public void ShowRandomOrder()
    {
        if (orderText != null)
        {
            int randomIndex = Random.Range(0, orders.Length);
            orderText.text = orders[randomIndex];
            Debug.Log("New random order: " + orders[randomIndex]);
        }
        else
        {
            Debug.LogWarning("Order Text is not assigned in OrderManager.");
        }
    }
}