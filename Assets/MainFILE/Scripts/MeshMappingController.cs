using UnityEngine;

public class MeshMappingController : MonoBehaviour
{
    public float startPercentage = 0.0f; // The start percentage of the mesh mapping (0.0 - 1.0)
    public float endPercentage = 1.0f;   // The end percentage of the mesh mapping (0.0 - 1.0)

    private MeshRenderer meshRenderer;
    private Material meshMaterial;

    private void Start()
    {
        // Get the MeshRenderer component attached to this GameObject
        meshRenderer = GetComponent<MeshRenderer>();

        // Make sure the MeshRenderer is not null
        if (meshRenderer != null)
        {
            // Get the material used by the MeshRenderer
            meshMaterial = meshRenderer.material;
        }
        else
        {
            Debug.LogError("MeshRenderer component not found!");
        }
    }

    private void Update()
    {
        // Check if the meshMaterial and shader support mapping
        if (meshMaterial != null && meshMaterial.shader.name.Contains("Unlit"))
        {
            // Calculate the start and end UV mapping values based on percentages
            Vector2 startMapping = new Vector2(startPercentage, 0.0f);
            Vector2 endMapping = new Vector2(endPercentage, 1.0f);

            // Set the start and end mapping values in the material
            meshMaterial.SetVector("_MappingStart", startMapping);
            meshMaterial.SetVector("_MappingEnd", endMapping);
        }
        else
        {
            Debug.LogError("Mesh material or shader does not support mapping!");
        }
    }
}