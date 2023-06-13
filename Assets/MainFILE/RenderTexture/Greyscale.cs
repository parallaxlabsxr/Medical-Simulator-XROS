using UnityEngine;
using System.Collections;

public class Greyscale : MonoBehaviour
{
    public Material mat;

    void Start()
    {
        mat.SetFloat("_Power", 0.0f);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, mat);
    }
}