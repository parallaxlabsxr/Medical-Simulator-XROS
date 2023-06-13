using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SheathController : MonoBehaviour
{

    public GameObject sheath;
    public GameObject sheathHighlighter;
    public GameObject uiGuide;
    public GameObject uiInserted;
    public GameObject sheathInAction;
    public GameObject CathetherWIRE;
    public GameObject CathetherWIRE2;
    public GameObject CathetherWIREHand;
    public GameObject CathetherWIREUI;
    public GameObject CathetherWIRECompletionUI;
    public Slider slider;
    


    public GameObject objectToDeActivate;
    public float delayInSeconds = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sheath"))
        {
            sheath.SetActive(false);
            sheathHighlighter.SetActive(false);
            uiGuide.SetActive(false);
            uiInserted.SetActive(true);
            sheathInAction.SetActive(true);

            CathetherWIREHand.SetActive(true);
            CathetherWIREUI.SetActive(true);
            CathetherWIRE2.SetActive(true);
            CathetherWIRE.SetActive(true);


           




        }
    }

    private void Update()
    {
        if (slider.value >= 499.0f)
        {
            CathetherWIREHand.SetActive(false);
            CathetherWIREUI.SetActive(false);
            CathetherWIRE2.SetActive(false);
            CathetherWIRE.SetActive(false);
            CathetherWIRECompletionUI.SetActive(true);
            uiGuide.SetActive(false);
            uiInserted.SetActive(false);


            StartCoroutine(ActivateObjectCoroutine());

        }
    }


    private System.Collections.IEnumerator ActivateObjectCoroutine()
    {
        yield return new WaitForSeconds(delayInSeconds);
        objectToDeActivate.SetActive(false);


        sheathInAction.SetActive(false);
        CathetherWIRECompletionUI.SetActive(false);
        
        


    }


    
}
