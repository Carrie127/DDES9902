using UnityEngine;
using TMPro;
using System.Collections;

public class FloatingTextFade : MonoBehaviour
{
    public float fadeDuration = 0.5f;
    public float displayTime = 1.5f;
    public float floatSpeed = 0.2f;

    private TextMeshPro textMesh;
    private Color originalColor;
    private Vector3 startPos;

    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
        originalColor = textMesh.color;
        startPos = transform.position;

        // 一开始完全透明
        textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }

    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        transform.position = startPos;

        // 淡入
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = t / fadeDuration;

            textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            transform.position += Vector3.up * floatSpeed * Time.deltaTime;

            yield return null;
        }

        // 停留
        yield return new WaitForSeconds(displayTime);

        // 淡出
        t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = 1 - (t / fadeDuration);

            textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            transform.position += Vector3.up * floatSpeed * Time.deltaTime;

            yield return null;
        }

        // 彻底隐藏
        textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}