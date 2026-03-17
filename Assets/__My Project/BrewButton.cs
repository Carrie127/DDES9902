using UnityEngine;
using System.Collections;

public class BrewButton : MonoBehaviour
{
    public CupDetector cupDetector;
    public float brewTime = 3f;
    private bool isBrewing = false;

    private Renderer buttonRenderer;
    private Color originalColor;

    // 更像现实设备的暖色提示，不要太鲜艳
    private Color brewingColor = new Color(0.95f, 0.75f, 0.35f);

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();

        if (buttonRenderer != null)
        {
            originalColor = buttonRenderer.material.color;
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
        if (isBrewing)
        {
            Debug.Log("Already brewing...");
            return;
        }

        if (cupDetector == null || !cupDetector.hasCup)
        {
            Debug.Log("No cup!");
            return;
        }

        StartCoroutine(BrewProcess());
    }

    IEnumerator BrewProcess()
    {
        isBrewing = true;
        Debug.Log("Brewing coffee...");

        // 开始制作：按钮变成柔和暖色
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = brewingColor;
        }

        yield return new WaitForSeconds(brewTime);

        Debug.Log("Coffee ready!");
        Debug.Log("Order complete!");

        // 完成后恢复原色
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = originalColor;
        }

        isBrewing = false;
    }
}