using UnityEngine;

public class LookAtYAxis : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            targetPosition.y = transform.position.y; // Ignore target's Y position

            transform.LookAt(targetPosition);
        }
    }
}



