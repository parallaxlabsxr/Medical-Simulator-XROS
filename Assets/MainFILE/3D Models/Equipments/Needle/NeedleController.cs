using UnityEngine;
using UnityEngine.UI;

public class NeedleController : MonoBehaviour
{
    public GameObject needle;
    public GameObject needleHighlighter;
    public GameObject uiGuide;
    public GameObject uiInserted;
    public GameObject needleInAction;
    public GameObject GuideWIRE;
    public GameObject GuideWIRE2;
    public GameObject GuideWIREHand;
    public GameObject GuideWIREUI;
    public GameObject GuideWIRECompletionUI;
    public Slider slider;
    public GameObject SheathHINT;
    public GameObject SheathUIPickupUI;


    public GameObject objectToDeActivate;
    public float delayInSeconds = 3f;

    public Collider objectCollider;
    public Rigidbody objectRigidbody;





    private bool isAnimationPlaying;

    /*public GameObject needleUI;


    public GameObject ShowSheathPickupUI;*/
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Needle"))
        {
            needle.SetActive(false);
            needleHighlighter.SetActive(false);
            uiGuide.SetActive(false);
            uiInserted.SetActive(true);
            needleInAction.SetActive(true);
            
            GuideWIREHand.SetActive(true);
            GuideWIREUI.SetActive(true);
            GuideWIRE2.SetActive(true);
            GuideWIRE.SetActive(true);
            

            isAnimationPlaying = true; 

           
    

        }
    }

    private void Update()
    {
        if ( slider.value >= 499.0f )
        {
            GuideWIREHand.SetActive(false);
            GuideWIREUI.SetActive(false);
            GuideWIRE2.SetActive(false);
            GuideWIRE.SetActive(false);
            GuideWIRECompletionUI.SetActive(true);
            uiGuide.SetActive(false);
            uiInserted.SetActive(false);
            

            StartCoroutine(ActivateObjectCoroutine());

        }
    }


    private System.Collections.IEnumerator ActivateObjectCoroutine()
    {
        yield return new WaitForSeconds(delayInSeconds);
        objectToDeActivate.SetActive(false);


        needleInAction.SetActive(false);
        GuideWIRECompletionUI.SetActive(false);
        SheathHINT.SetActive(true);
        SheathUIPickupUI.SetActive(true);
        objectRigidbody.isKinematic = false;
        objectCollider.enabled = true;
        gameObject.SetActive(false);


    }

    private void DisableObject()
    {
        /* needleUI.SetActive(false);
         needleInAction.SetActive(false);

         ShowSheathPickupUI.SetActive(true); */
    }



}