using UnityEngine;

public class PickupArea : MonoBehaviour
{
    public Renderer pickupRenderer;

    public Material defaultMaterial;
    public Material readyMaterial;

    void Start()
    {
        SetDefault();
    }

    public void SetReady()
    {
        if (pickupRenderer != null && readyMaterial != null)
        {
            pickupRenderer.material = readyMaterial;
        }
    }

    public void SetDefault()
    {
        if (pickupRenderer != null && defaultMaterial != null)
        {
            pickupRenderer.material = defaultMaterial;
        }
    }
}