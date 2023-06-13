using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimControl : MonoBehaviour
{
    

    private Animator anim;
    public Slider slider;   //Assign the UI slider of your scene in this slot 

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("WIREInserter", -1, slider.normalizedValue);
    }

}