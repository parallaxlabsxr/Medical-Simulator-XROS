using UnityEngine;
using UnityEngine.UI;

public class WIRESlider : MonoBehaviour
{
    public Slider slider; // Reference to the Slider component
    public float minValue = 512.0002f; // Minimum value for the 'newBottomValue'
    public float maxValue = -0.0002441406f; // Maximum value for the 'newBottomValue'

    private Image image;
    private RectTransform rectTransform;

    private void Start()
    {
        image = GetComponent<Image>(); // Get the Image component attached to the same GameObject
        rectTransform = image.rectTransform; // Get the RectTransform component of the Image

        slider.minValue = minValue; // Set the minimum value for the slider
        slider.maxValue = maxValue; // Set the maximum value for the slider
    }

    private void Update()
    {
        

        float newPosition = slider.value;

        // Calculate the 'bottom' value based on the slider value
        float bottomValue = newPosition;

        // Calculate the 'top' value based on the slider value
        float topValue = maxValue - newPosition;

        // Update the 'bottom' and 'top' values of the RectTransform
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, bottomValue);
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -topValue);
    }
}





