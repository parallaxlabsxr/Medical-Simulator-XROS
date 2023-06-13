using UnityEngine;
using UnityEngine.UI;

public class WirePushBoxController : MonoBehaviour
{
    
    public string rightWireTagName = "RightWIRE";
    public GameObject RightHandHighlight;
    public DistanceCalculator valueProvider;
   
    public GameObject FirstTriggersGameObject;



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(rightWireTagName))
        {
            RightHandHighlight.SetActive(false);
                     
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(rightWireTagName))
        {
            
            FirstTriggersGameObject.SetActive(true);

        }

    }



    private void Update()
    {
        float myFloat = valueProvider.distance;
        Debug.Log("Float value: " + myFloat);

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(rightWireTagName))
        {
            RightHandHighlight.SetActive(true);
        }
    }
}






