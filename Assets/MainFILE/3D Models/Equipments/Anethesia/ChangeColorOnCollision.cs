using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour
{
     
    public GameObject anesthesiaHandle;
    public GameObject uiSuccessfulInserted;
    public GameObject uiNeedlePickup;
    public GameObject uiInserted;

    public GameObject objectToDeActivate;
    public float delayInSeconds = 3f;

    public static int isProcessStartedAnesthesia = 0;


    public Collider objectCollider;
    public Rigidbody objectRigidbody;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anesthesia")) // Assuming the trigger belongs to the "Player" GameObject
        {
            Renderer renderer = anesthesiaHandle.GetComponent<Renderer>();
            Material material = renderer.material;
            material.color = Color.green;
            renderer.material = material;

           



        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (PusherLiquidController.gripValue >= 0.9f)
        {
            isProcessStartedAnesthesia = 1;
            
            uiSuccessfulInserted.SetActive(true);



            uiInserted.SetActive(false);


            StartCoroutine(ActivateObjectCoroutine());






        }
    }

    private System.Collections.IEnumerator ActivateObjectCoroutine()
    {
        yield return new WaitForSeconds(delayInSeconds);
        objectToDeActivate.SetActive(false);
        uiNeedlePickup.SetActive(true);
        gameObject.SetActive(false);
        objectRigidbody.isKinematic = false;
        objectCollider.enabled = true;
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Anesthesia")) // Assuming the trigger belongs to the "Player" GameObject
        {
            Renderer renderer = anesthesiaHandle.GetComponent<Renderer>();
            Material material = renderer.material;
            material.color = Color.red;
            renderer.material = material;
            
        }
    }
}