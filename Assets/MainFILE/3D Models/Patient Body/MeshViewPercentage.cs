using UnityEngine;
using UnityEngine.UI;

public class MeshViewPercentage : MonoBehaviour
{
    public AnimationCurve curveMapping;

    private void Update()
    {
        // Calculate the mapping value based on time
        float normalizedTime = Time.time % 1f; // Normalize time between 0 and 1
        float mappingValue = curveMapping.Evaluate(normalizedTime);

        // Use the mapping value to control an object's position along the curve
        Vector3 newPosition = GetPointOnCurve(mappingValue);
        transform.position = newPosition;
    }

    private Vector3 GetPointOnCurve(float t)
    {
        // Replace this with your own implementation to calculate the position on the curve
        // You can use the t parameter to interpolate points on the curve
        // For example, you can use Mathf.Lerp or Vector3.Lerp to interpolate between control points
        // and calculate the position along the curve

        Vector3 startPoint = Vector3.zero;
        Vector3 controlPoint1 = new Vector3(1, 2, 0);
        Vector3 controlPoint2 = new Vector3(3, 2, 0);
        Vector3 endPoint = new Vector3(4, 0, 0);

        Vector3 pointOnCurve = Mathf.Pow(1 - t, 3) * startPoint +
                               3 * Mathf.Pow(1 - t, 2) * t * controlPoint1 +
                               3 * (1 - t) * Mathf.Pow(t, 2) * controlPoint2 +
                               Mathf.Pow(t, 3) * endPoint;

        return pointOnCurve;
    }
}