using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    private Vector3 oldPosition;
    private Vector3 newPosition;
    private Quaternion oldRotation;
    private Quaternion newRotation;
    private float journeyTime = 1.0f; // 1 second

    void Start()
    {
        oldPosition = new Vector3(0.000445798f, 1.037554f, 0.001080453f);
        newPosition = new Vector3(0.0004261993f, 1.037255f, 0.001035154f);
        oldRotation = Quaternion.Euler(82.13f, 274.378f, 107.285f);
        newRotation = Quaternion.Euler(64.149f, 180.817f, 14.779f);
    }

   

    public void CloseEye()
    {
        StartCoroutine(AnimateTransform(oldPosition, oldRotation));
    }

    public void OpenEye()
    {
        StartCoroutine(AnimateTransform(newPosition, newRotation));
    }

    IEnumerator AnimateTransform(Vector3 targetPosition, Quaternion targetRotation)
    {
        float startTime = Time.time;
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;

        while (Time.time < startTime + journeyTime)
        {
            float journeyFraction = (Time.time - startTime) / journeyTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, journeyFraction);
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, journeyFraction);
            yield return null;
        }

        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
}
