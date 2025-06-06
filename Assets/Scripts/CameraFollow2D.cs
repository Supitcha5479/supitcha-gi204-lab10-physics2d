using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
   Vector3 offset = new Vector3 (0f, 0f, -10f);
    float smoothTime = 0.25f;
    Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity,smoothTime);
    }
}
