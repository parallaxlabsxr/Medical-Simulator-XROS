using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class PusherLiquidController : MonoBehaviour
{
    public GameObject anesthesiaHighlighter;
    public GameObject uiGuide;
    public GameObject uiInserted;
    public GameObject uiSuccessfulInserted;

    public SteamVR_Input_Sources inputSource;
    public SteamVR_Action_Single gripAction;
    public Slider slider;


    public static float gripValue;


    public Transform yAxisTransform;
    public float minYValue = 0f;
    public float maxYValue = 16f;


    public GameObject liquid;

  




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anesthesia") && !uiSuccessfulInserted.activeSelf)
        {
            anesthesiaHighlighter.SetActive(false);
            uiGuide.SetActive(false);

            uiInserted.SetActive(true);
        
                
            


            


            
        }
    }

   



    private void Update()
    {
        gripValue = gripAction.GetAxis(inputSource);
        slider.value = gripValue;


        float newYValue = Mathf.Lerp(minYValue, maxYValue, slider.value);
        yAxisTransform.localPosition = new Vector3(yAxisTransform.localPosition.x, newYValue, yAxisTransform.localPosition.z);

        float liquidScale = Mathf.Lerp(1f, 0f, slider.value);
        Vector3 liquidScaleVector = liquid.transform.localScale;
        liquidScaleVector.y = liquidScale;
        liquid.transform.localScale = liquidScaleVector;

    }


    
    




}