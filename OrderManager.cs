using UnityEngine;
using TMPro;

public class OrderManager : MonoBehaviour
{
    public TextMeshProUGUI orderText;

    int orderIndex = 0;

    string[] orders =
    {
        "Order #101\n\n1 Latte\n1 Cappuccino\n\nTakeaway",
        "Order #102\n\n1 Flat White\n\nDine In",
        "Order #103\n\n1 Espresso\n1 Latte\n\nTakeaway"
    };

    void Start()
    {
        InvokeRepeating("NextOrder", 5f, 8f);
    }

    void NextOrder()
    {
        orderText.text = orders[orderIndex];
        orderIndex++;

        if (orderIndex >= orders.Length)
        {
            orderIndex = 0;
        }
    }
}