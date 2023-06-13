using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    public GameObject rightHandDistance;
    public string leftWireTagName = "LeftWIRE";
    public GameObject leftHandHighlight;
    public float distance;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(leftWireTagName))
        {
            leftHandHighlight.SetActive(false);
            distance = Vector3.Distance(transform.position, rightHandDistance.transform.position);
            /*Debug.Log("Distance between " + gameObject.name + " and RightHandDistance: " + distance);*/

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(leftWireTagName))
        {
            leftHandHighlight.SetActive(true);
        }
    }    
}