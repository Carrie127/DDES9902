using UnityEngine;
using System.Collections;

public class BrewButton : MonoBehaviour
{
    [Header("References")]
    public CupDetector cupDetector;
    public FloatingTextFade coffeeReadyEffect;

    [Header("Settings")]
    public float brewTime = 3f;

    private bool isBrewing = false;

    private Renderer buttonRenderer;
    private Color originalColor;

    // 柔和一点的“工作中”颜色，更像设备状态提示
    private Color brewingColor = new Color(0.9f, 0.75f, 0.5f);

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

        // 按钮进入“工作状态”
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = brewingColor;
        }

        yield return new WaitForSeconds(brewTime);

        Debug.Log("Coffee ready!");
        Debug.Log("Order complete!");

        // 按钮恢复原色
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = originalColor;
        }

        // 播放 Coffee Ready 提示动画
        if (coffeeReadyEffect != null)
        {
            coffeeReadyEffect.Play();
        }

        isBrewing = false;
    }
}