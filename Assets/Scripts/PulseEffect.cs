using UnityEngine;

public class PulseEffect : MonoBehaviour
{
    public RectTransform uiElement; // Assign in Inspector or automatically detected
    public float pulseSpeed = 2f;    // Speed of pulsing
    public float scaleAmount = 0.1f; // Max scale difference from original

    private Vector3 originalScale;

    void Start()
    {
        if (uiElement == null)
        {
            uiElement = GetComponent<RectTransform>();
        }

        originalScale = uiElement.localScale;
    }

    void Update()
    {
        float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * scaleAmount;
        uiElement.localScale = originalScale * scale;
    }
}
