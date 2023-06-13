using UnityEngine;

public class BlendShapeAnimation : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer; // Reference to the SkinnedMeshRenderer component
    public string blendShapeName; // Name of the blend shape you want to animate
    public float animationDuration = 0.4f; // Total duration of the animation in seconds

    private float currentTime = 0f; // Current time elapsed in the animation
    private bool isAnimating = false; // Flag to indicate if the animation is currently in progress
    private int blendShapeIndex = -1; // Index of the blend shape in the SkinnedMeshRenderer

    private void Start()
    {
        // Check if the SkinnedMeshRenderer and blend shape name are provided
        if (skinnedMeshRenderer == null || string.IsNullOrEmpty(blendShapeName))
        {
            Debug.LogError("SkinnedMeshRenderer or blend shape name is missing!");
            return;
        }

        // Get the index of the blend shape
        blendShapeIndex = skinnedMeshRenderer.sharedMesh.GetBlendShapeIndex(blendShapeName);

        // Check if the blend shape exists
        if (blendShapeIndex == -1)
        {
            Debug.LogError("Blend shape with name " + blendShapeName + " not found!");
            return;
        }

        // Start the animation
        StartAnimation();
    }

    private void Update()
    {
        if (isAnimating)
        {
            // Calculate the current weight based on the elapsed time
            float currentWeight = Mathf.PingPong(Time.time, animationDuration) / animationDuration;

            // Map the weight from 0 to 1 to the range of 0 to 100
            float blendShapeWeight = Mathf.Lerp(0f, 100f, currentWeight);

            // Set the blend shape weight
            skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, blendShapeWeight);
        }
    }

    private void StartAnimation()
    {
        // Reset the current time and flag
        currentTime = 0f;
        isAnimating = true;
    }
}