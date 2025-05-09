using UnityEngine;

public class ShowCredits : MonoBehaviour
{   
    public RectTransform uiElement; // Assign in inspector
    public Vector2 offScreenPosition; // Target position off-screen
    public float moveSpeed = 5f;
    public bool slideOut = false;

    private Vector2 originalPosition;
    private bool isSliding = false;

    void Start()
    {
        if (uiElement == null)
        {
            uiElement = GetComponent<RectTransform>();
        }

        originalPosition = uiElement.anchoredPosition;
    }

    void Update()
    {
        if (isSliding)
        {
            Vector2 targetPosition = slideOut ? offScreenPosition : originalPosition;
            uiElement.anchoredPosition = Vector2.Lerp(uiElement.anchoredPosition, targetPosition, Time.deltaTime * moveSpeed);

            // Stop sliding when close to target
            if (Vector2.Distance(uiElement.anchoredPosition, targetPosition) < 0.1f)
            {
                uiElement.anchoredPosition = targetPosition;
                isSliding = false;
            }
        }
    }

    public void SlideOut()
    {
        slideOut = true;
        isSliding = true;
        PlayMusic.instance.PlayMenuClick();
    }

    public void SlideIn()
    {
        slideOut = false;
        isSliding = true;
        PlayMusic.instance.PlayMenuClick();
    }

    // Optional toggle function
    public void ToggleSlide()
    {
        slideOut = !slideOut;
        isSliding = true;
    }
}
